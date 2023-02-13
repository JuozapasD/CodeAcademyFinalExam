using CodeAcademyFinalExam.DAL;
using CodeAcademyFinalExam.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Numerics;
using System.Security.Claims;

namespace CodeAcademyFinalExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanInformationController : ControllerBase
    {
        private readonly IHumanInformationDbRepository _humanInformation;

        public HumanInformationController(IHumanInformationDbRepository humanInformation)
        {
            _humanInformation = humanInformation;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User, Admin")]
        [HttpPost]
        public void PostItem(HumanInformationDto infoToAdd)
        {
            var userIdStr = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var useridInt = int.Parse(userIdStr);

            _humanInformation.AddNewUserToList(useridInt, infoToAdd);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User, Admin")]
        [HttpPut]
        public void UpdateItem([FromBody] HumanInformationDto human)
        {
            var userIdStr = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var useridInt = int.Parse(userIdStr);
            _humanInformation.UpdateUserById(useridInt, human.Name,  human.Surname, human.PersonalCode, 
                human.TelephoneNumber, human.Email, human.Address.City, human.Address.Street, 
                human.Address.HouseNumber, human.Address.FlatNumber );
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet("GetAllAccounts")]
        public List<AccountDto> GetAllAccounts()
        {
            return _humanInformation.GetAllAccounts();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _humanInformation.DeleteUserById(id);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet("GetAllUserInformation")]
        public IActionResult GetAllUserInformation()
        {
            var allUserInfo = _humanInformation.GetAllUserInfo();
            return Ok(allUserInfo);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User, Admin")]
        [HttpGet("user")]
        public IActionResult GetUserInformation()
        {
            var userIdStr = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var useridInt = int.Parse(userIdStr);
            var userInfo = _humanInformation.GetUserInformationById(useridInt);
            return Ok(userInfo);
        }
    }
}
