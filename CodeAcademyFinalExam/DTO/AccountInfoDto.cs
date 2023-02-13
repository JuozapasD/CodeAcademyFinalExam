using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeAcademyFinalExam.DTO
{
    public class AccountInfoDto
    {
        [Required]
        public string Username { get; set; }

        public string Role { get; set; }
    }
}
