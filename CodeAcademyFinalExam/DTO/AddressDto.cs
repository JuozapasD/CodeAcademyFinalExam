using System.ComponentModel.DataAnnotations;

namespace CodeAcademyFinalExam.DTO
{
    public class AddressDto
    {
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string HouseNumber { get; set; }
        [Required]
        public string FlatNumber { get; set; }
    }
}