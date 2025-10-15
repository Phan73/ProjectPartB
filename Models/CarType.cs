using System;
using System.Collections.Generic;

namespace ProjectPartB.Models
{
    public partial class CarType
    {
        

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CarDescription> CarDescriptions { get; set; }
    }
}
