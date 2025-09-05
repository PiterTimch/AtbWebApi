using Core.Models.Account;

namespace Core.Interfaces
{
    public interface IAccountService
    {
        public Task<string> RegisterAsync(RegisterModel model);
        public Task SeedRolesAsync();
    }
}
