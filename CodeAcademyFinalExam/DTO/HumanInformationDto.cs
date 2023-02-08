using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeAcademyFinalExam.DTO
{
    public class HumanInformationDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PersonalCode { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public int AddressId { get; set; }

        public Address Address { get; set; }
    }
}
