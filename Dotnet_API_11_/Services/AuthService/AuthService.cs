using Dotnet_API_11_.Data;
using Dotnet_API_11_.Dtos.UserDto;
using Dotnet_API_11_.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Dotnet_API_11_.Services.AuthService
{
    public class AuthService(StudentAuthDbContext _context, IConfiguration configuration) : IAuthService
    {
        public async Task<string> login(UserDto request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(X => X.UserName == request.UserName);

            if (user is null)
                return null;

            if(user.UserName != request.UserName)
            {
                return null;
            }

            if(new PasswordHasher<User>().VerifyHashedPassword(user,user.PasswordHash,request.Password)== PasswordVerificationResult.Failed){
                return null;
            }

            string token = CreateToken(user);

            return token;
        }

        public async Task<User> Register(UserDto request)
        {
            if (await _context.Users.AnyAsync(x => x.UserName == request.UserName))
            {
                return null;
            }
            var user = new User
            {
                UserName = request.UserName,
                Role = request.Role ?? "User"
            };
            var HashPassword = new PasswordHasher<User>().HashPassword(user, request.Password);

            user.UserName = request.UserName;
            user.PasswordHash=HashPassword;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Role,user.Role)  
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration.GetValue<string>("AppSettings:Token")!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var tokenDescriptor = new JwtSecurityToken(

                issuer: configuration.GetValue<string>("AppSettings:Issuer"),
                audience: configuration.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds

                );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

        }
    }
}
