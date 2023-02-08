using CodeAcademyFinalExam.BLL;
using CodeAcademyFinalExam.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeAcademyFinalExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountsService;
        private readonly IJwtService _jwtService;
        public AccountsController(IAccountService accountsService, IJwtService jwtService)
        {
            _accountsService = accountsService;
            _jwtService = jwtService;
        }

        [HttpPost("SignUp")]
        public ActionResult SignUp([FromBody] AuthRequestDto request)
        {
            _accountsService.SignupNewAccount(request.UserName, request.Password);
            return Ok();
        }

        [HttpPost("Login")]
        public ActionResult Login([FromBody] AuthRequestDto request)
        {
            var (loginSuccess, account) = _accountsService.Login(request.UserName, request.Password);
            if (!loginSuccess)
            {
                return BadRequest("Invalid username or password");
            }
            else
            {
                var jwt = _jwtService.GetJwtToken(account.Username, account.Id, account.Role);
                return Ok(jwt);
            }
        }
    }
}
