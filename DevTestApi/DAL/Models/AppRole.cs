using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DevTestApi.DAL.Models
{
    public class AppRole : IdentityRole
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}