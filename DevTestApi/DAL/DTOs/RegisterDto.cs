﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DevTestApi.DAL.DTOs
{
    [DisplayName("Register")]
    public class RegisterDto
    {
        [Required] 
        public string Username { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string KnownAs { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
        
        public string Gender { get; set; }
        
        [Required]
        [StringLength(8, MinimumLength = 4)]
        public string Password { get; set; }
    }
}