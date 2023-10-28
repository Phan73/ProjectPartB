using System;
using System.Collections.Generic;

namespace ProjectPartB.Models
{
    public partial class Rental
    {
        public int RentalId { get; set; }
        public int? UserId { get; set; }
        public int? CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal? TotalPrice { get; set; }

        public virtual CarDescription? Car { get; set; }
        public virtual User? User { get; set; }
    }
}
