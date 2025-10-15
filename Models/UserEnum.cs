using System;
using System.Collections.Generic;

namespace ProjectPartB.Models
{
    public partial class UserEnum
    {
        public UserEnum()
        {
            UserDescriptions = new HashSet<UserDescription>();
        }

        public int UserEnumId { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<UserDescription> UserDescriptions { get; set; }
    }
}
