using System;
using System.Collections.Generic;

namespace ProjectPartB.Models
{
    public partial class UserType
    {
        public UserType()
        {
            Users = new HashSet<User>();
        }

        public int TypeId { get; set; }
        public string TypeName { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
