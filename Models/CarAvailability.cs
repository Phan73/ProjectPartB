using System;
using System.Collections.Generic;

namespace ProjectPartB.Models
{
    public partial class CarAvailability
    {
        public int CarAvailabilityId { get; set; }
        public int? CarDescriptionId { get; set; }
        public bool? IsAvailable { get; set; }

        public virtual CarDescription? CarDescription { get; set; }
    }
}
