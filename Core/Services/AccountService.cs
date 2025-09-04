using AutoMapper;
using Core.Interfaces;
using Core.Models.Account;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Core.Services
{
    internal class AccountService(IMapper mapper, IImageService imageService, UserManager<UserEntity> userManager) : IAccountService
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
            }
            return string.Empty;
        }
    }
}
