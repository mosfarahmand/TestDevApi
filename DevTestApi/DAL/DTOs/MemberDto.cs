using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DevTestApi.DAL.DTOs
{
    [DisplayName("Member")]
    public class MemberDto
    {
        public Guid UserId { get; set; } = Guid.NewGuid();

        public string UserName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:YYYY-MM-dd}")]
        public DateTime DateOfBirth { get; set; }

        public string KnownAs { get; set; }
        
        public int Age { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public DateTime LastActive { get; set; } = DateTime.Now;

        public string Gender { get; set; }
    }
}