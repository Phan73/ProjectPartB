using System;
using System.Collections.Generic;

namespace ProjectPartB.Models
{
    public partial class User
    {
        public User()
        {
            Rentals = new HashSet<Rental>();
        }

        public int UserId { get; set; }
        public int? TypeId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual UserType? Type { get; set; }
        public virtual UserDescription? UserDescription { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
