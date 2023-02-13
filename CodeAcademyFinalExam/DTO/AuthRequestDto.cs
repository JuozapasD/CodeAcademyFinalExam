using System.ComponentModel.DataAnnotations;

namespace CodeAcademyFinalExam.DTO
{
    public class AuthRequestDto
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string UserName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Password { get; set; }
    }
}
