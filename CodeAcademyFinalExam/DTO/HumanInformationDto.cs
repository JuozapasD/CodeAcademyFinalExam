﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeAcademyFinalExam.DTO
{
    public class HumanInformationDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string PersonalCode { get; set; }
        [Required]
        [Phone]
        public string TelephoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public AddressDto Address { get; set; }
    }
}
