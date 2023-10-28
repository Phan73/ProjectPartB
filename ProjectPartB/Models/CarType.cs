using System;
using System.Collections.Generic;

namespace ProjectPartB.Models
{
    public partial class CarType
    {
        public CarType()
        {
            CarDescriptions = new HashSet<CarDescription>();
        }

        public int CarTypeId { get; set; }
        public string TypeName { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<CarDescription> CarDescriptions { get; set; }
    }
}
