using AutoMapper;
using Core.Constants;
using Core.Interfaces;
using Core.Models.Account;
using Domain;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Core.Services;

public class AccountService(IMapper mapper, 
    IImageService imageService, 
    UserManager<UserEntity> userManager,
    AppDbAtbContext context,
    RoleManager<RoleEntity> roleManager,
    IJwtServise jwtServise) : IAccountService
{
    public async Task<string> RegisterAsync(RegisterModel model)
    {
        var user = mapper.Map<UserEntity>(model);
        if (model.ImageFile != null)
        {
            user.Image = await imageService.SaveImageAsync(model.ImageFile);
        }
        var result = await userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "User");
            return await jwtServise.CreateTokenAsync(user);
        }
        return string.Empty;
    }

    public async Task SeedRolesAsync() 
    {
        if (!context.Roles.Any())
        {
            var roles = Roles.AllRoles.Select(r => new RoleEntity(r)).ToList();

            foreach (var role in roles)
            {
                var result = await roleManager.CreateAsync(role);
                if (!result.Succeeded)
                {
                    Console.WriteLine("Error Create Role {0}", role.Name);
                }
            }
        }
    }
}
