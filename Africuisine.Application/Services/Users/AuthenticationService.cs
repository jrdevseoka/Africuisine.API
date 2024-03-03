using Africuisine.Application.Data.Command.Users;
using Africuisine.Application.Data.Config;
using Africuisine.Application.Data.Res;
using Africuisine.Application.Interfaces;
using Africuisine.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AutoMapper;
using Africuisine.Application.Data.User;
using Africuisine.Domain.Repositories.Repository;

namespace Africuisine.Application.Services.Users
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> UserManager;
        private readonly IMapper Mapper;
        private JwtConfig Jwt { get; set; }

        public AuthenticationService(UserManager<User> userManager, IOptions<JwtConfig> options, IMapper mapper)
        {
            UserManager = userManager;
            Jwt = options.Value;
            Mapper = mapper;
        }

        public async Task<Response> SigInWithEmailAndPassword(UserLoginCommand request)
        {
            var user = await UserManager.FindByEmailAsync(request.UserName);
            return new Response { Succeeded = user is not null && await UserManager.CheckPasswordAsync(user, request.Password) };
        }

        public Task<AuthResponse> SignInWithGoogleAuthentication()
        {
            throw new NotImplementedException();
        }
        public List<Claim> GenerateClaims(User user, IList<string> roles)
        {
            var claims = new List<Claim> {
                new(ClaimTypes.Name, user.Id),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.NameIdentifier, user.Id),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            foreach (string role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            };
            claims.Add(new(ClaimTypes.Expiration, DateTime.Now.AddHours(8).ToLongDateString()));
            return claims;
        }
        public string GenerateJwtToken(List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Jwt.Key));
            var securityToken = new JwtSecurityToken(
                issuer: Jwt.ValidIssuer,
                audience: Jwt.ValidAudiences.FirstOrDefault(),
                expires: DateTime.Now.AddHours(8),
                claims: claims,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }
    }
}
