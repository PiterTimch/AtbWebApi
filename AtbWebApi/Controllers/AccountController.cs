using Core.Interfaces;
using Core.Models.Account;
using Core.Models.Category;
using Microsoft.AspNetCore.Mvc;

namespace AtbWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(IAccountService accountService) : Controller
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromForm] RegisterModel model)
    {
        var result = await accountService.RegisterAsync(model);
        return Ok(result);
    }

    [HttpPost("seed-roles")]
    public async Task<IActionResult> SeedRoles()
    {
        await accountService.SeedRolesAsync();
        return Ok("Roles seeded successfully.");
    }
}
