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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
        [HttpPost]
        public void PostItem(HumanInformationDto infoToAdd)
        {
            var userIdStr = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var useridInt = int.Parse(userIdStr);

            _humanInformation.AddNewUserToList(useridInt, infoToAdd);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
        [HttpPut]
        public void UpdateItem([FromBody] HumanInformationDto human)
        {
            var userIdStr = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var useridInt = int.Parse(userIdStr);
            _humanInformation.UpdateUserById(useridInt, human.Name,  human.Surname, human.PersonalCode, 
                human.TelephoneNumber, human.Email, human.Address.City, human.Address.Street, 
                human.Address.HouseNumber, human.Address.FlatNumber );
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
        //[HttpGet]
        //public void GetItem([FromBody] HumanInformationDto human)
        //{
        //    var userIdStr = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
        //    var useridInt = int.Parse(userIdStr);
        //    _humanInformation.UpdateUserById(useridInt, human.Name, human.Surname, human.PersonalCode,
        //        human.TelephoneNumber, human.Email, human.Address.City, human.Address.Street,
        //        human.Address.HouseNumber, human.Address.FlatNumber);
        //}
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
        [HttpGet]
        public List<AccountDto> GetAllAccounts()
        {
            return _humanInformation.GetAllAccounts();
        }
    }
}
