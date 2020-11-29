using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DevTestApi.DAL.Models
{
    public class AppUser : IdentityUser
    {
        public DateTime DateOfBirth { get; set; }

        public string KnownAs { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public DateTime LastActive { get; set; } = DateTime.Now;

        public string Gender { get; set; }
        
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}