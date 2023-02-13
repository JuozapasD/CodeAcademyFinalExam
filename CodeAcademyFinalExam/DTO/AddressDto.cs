using System.ComponentModel.DataAnnotations;

namespace CodeAcademyFinalExam.DTO
{
    public class AddressDto
    {
        [Key]
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string FlatNumber { get; set; }
    }
}