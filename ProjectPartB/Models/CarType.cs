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
        public int TypeName { get; set; }

        public virtual ICollection<CarDescription> CarDescriptions { get; set; }
    }
}
