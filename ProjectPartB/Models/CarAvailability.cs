using System;
using System.Collections.Generic;

namespace ProjectPartB.Models
{
    public partial class CarAvailability
    {
        public CarAvailability()
        {
            CarDescriptions = new HashSet<CarDescription>();
        }

        public int AvailabilityId { get; set; }
        public string Status { get; set; } = null!;

        public virtual ICollection<CarDescription> CarDescriptions { get; set; }
    }
}
