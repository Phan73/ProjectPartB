using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectPartB.Models
{
    public partial class CarDescription
    {
        public CarDescription()
        {
            Rentals = new HashSet<Rental>();
        }
        [Key]
        public int CarId { get; set; }
        public int? CarTypeId { get; set; }
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int? Year { get; set; }
        public string? Color { get; set; }
        public decimal? PricePerDay { get; set; }
        public int? AvailabilityId { get; set; }

        public virtual CarAvailability? Availability { get; set; }
        public virtual CarType? CarType { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
