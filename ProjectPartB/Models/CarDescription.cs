using System;
using System.Collections.Generic;

namespace ProjectPartB.Models
{
    public partial class CarDescription
    {
        public CarDescription()
        {
            CarAvailabilities = new HashSet<CarAvailability>();
            Rentals = new HashSet<Rental>();
        }

        public int CarDescriptionId { get; set; }
        public int? CarTypeId { get; set; }
        public string? Description { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? Color { get; set; }
        public decimal? RatePerDay { get; set; }
        public bool? Available { get; set; }

        public virtual CarType? CarType { get; set; }
        public virtual ICollection<CarAvailability> CarAvailabilities { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
