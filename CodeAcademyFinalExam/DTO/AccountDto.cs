﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeAcademyFinalExam.DTO
{
    public class AccountDto
    {
        [Required]
        public string Username { get; set; }

        public string Role { get; set; }
        public HumanInformationDto HumanInformation { get; internal set; }
    }
}
