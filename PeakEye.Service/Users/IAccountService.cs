using PeakEye.Service.Users.Dtos;
using System.IdentityModel.Tokens.Jwt;

namespace PeakEye.Service.Users
{
    public interface IAccountService
    {
        Task<ServiceResult> Register(RegisterDto request);
        Task<ServiceResult<JwtTokenDto>> Login(LoginDto request);
    }
}
