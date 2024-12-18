using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PeakEye.Repository.Users;
using PeakEye.Service.Users.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace PeakEye.Service.Users
{
    public class AccountService(UserManager<AppUser> userManager, IConfiguration configuration) : IAccountService
    {
        public async Task<ServiceResult<JwtTokenDto>> Login(LoginDto request)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            var password = await userManager.CheckPasswordAsync(user, request.Password);
            
            if (user != null && password)
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);

                var tokenDto = new JwtTokenDto
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                };

                return ServiceResult<JwtTokenDto>.Success(tokenDto);
            }

            return ServiceResult<JwtTokenDto>.Fail("E posta veya şifre yanlış!", HttpStatusCode.Unauthorized);
        }

        public async Task<ServiceResult> Register(RegisterDto request)
        {
            var userExists = await userManager.FindByNameAsync(request.UserName!);

            if (userExists != null)
                return ServiceResult.Fail("Kullanıcı adı daha önce alınmış", HttpStatusCode.InternalServerError);


            AppUser user = new()
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.UserName,
                Name = request.UserName,
                Surname = request.UserName,
                Id = Guid.NewGuid().ToString(),
            };

            var result = await userManager.CreateAsync(user, request.Password!);

            if (!result.Succeeded)
                return ServiceResult.Fail("Kullanıcı oluşturulamadı, lütfen tekrar deneyin.", HttpStatusCode.InternalServerError);

            return ServiceResult.Success(HttpStatusCode.OK);
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
