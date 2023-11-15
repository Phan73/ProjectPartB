using System;
using System.Collections.Generic;

namespace ProjectPartB.Models
{
    public partial class UserDescription
    {
        public UserDescription()
        {
          
        }

        public int UserId { get; set; }
        public int? UserEnumId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public virtual UserEnum? UserEnum { get; set; }
       
    }
}
