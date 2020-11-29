using System;
using System.ComponentModel;

namespace DevTestApi.DAL.DTOs
{
    [DisplayName("Member Update")]
    public class MemberUpdateDto
    {
        public DateTime DateOfBirth { get; set; }

        public string KnownAs { get; set; }
        
        public string Gender { get; set; }
    }
}