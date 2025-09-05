using Domain.Entities.Identity;

namespace Core.Interfaces;

public interface IJwtServise
{
    Task<string> CreateTokenAsync(UserEntity user);
}
