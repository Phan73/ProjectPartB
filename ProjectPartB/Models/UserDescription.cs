using System;
using System.Collections.Generic;

namespace ProjectPartB.Models
{
    public partial class UserDescription
    {
        public int UserDescriptionId { get; set; }
        public int? UserId { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string DrivingLicense { get; set; } = null!;

        public virtual User? User { get; set; }
    }
}
