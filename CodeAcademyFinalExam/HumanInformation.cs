using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace CodeAcademyFinalExam
{
    public class HumanInformation
    {
        [Key]
        public int HumanInformationId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PersonalCode { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public Address Address { get; set; }
    }
}