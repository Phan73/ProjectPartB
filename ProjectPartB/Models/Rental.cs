using System;
using System.Collections.Generic;

namespace ProjectPartB.Models
{
    public partial class Rental
    {
        public int RentalId { get; set; }
        public int? CarDescriptionId { get; set; }
        public int? UserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? TotalCost { get; set; }

        public virtual CarDescription? CarDescription { get; set; }
        public virtual UserDescription? User { get; set; }
    }
}
