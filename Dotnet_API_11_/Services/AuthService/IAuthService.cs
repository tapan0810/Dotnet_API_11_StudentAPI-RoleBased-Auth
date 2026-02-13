using Dotnet_API_11_.Dtos.UserDto;
using Dotnet_API_11_.Entities;

namespace Dotnet_API_11_.Services.AuthService
{
    public interface IAuthService
    {
        Task<User> Register(UserDto request);
        Task<string> login(UserDto request);
    }
}
