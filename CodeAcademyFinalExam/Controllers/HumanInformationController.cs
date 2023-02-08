using CodeAcademyFinalExam.DAL;
using CodeAcademyFinalExam.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Numerics;

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
        public void PostItem(int userId, HumanInformationDto infoToAdd)
        {
            _humanInformation.AddNewUserToList(userId, infoToAdd);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
        [HttpPut]
        public void UpdateItem([FromQuery] int id, [FromBody] HumanInformationDto human)
        {
            _humanInformation.UpdateUserById(id, human.Name,  human.Surname, human.PersonalCode, human.TelephoneNumber, human.Email );
        }
        
    }
}
