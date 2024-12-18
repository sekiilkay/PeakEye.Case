using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeakEye.Service.Users;
using PeakEye.Service.Users.Dtos;

namespace PeakEye.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController(IAccountService accountService) : CustomBaseController
    {
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto request) => CreateActionResult(await accountService.Register(request));

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto request) => CreateActionResult(await accountService.Login(request));
    }
}
