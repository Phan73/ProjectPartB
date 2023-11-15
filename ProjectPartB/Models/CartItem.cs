using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectPartB.Models
{
    public class CartItem
    {
        [Key]
        public string AspNetUserId { get; set; } // Foreign key to AspNetUser table
        [ForeignKey("AspNetUserId")]
        public AspNetUser AspNetUser { get; set; }
        public int CarDescriptionId { get; set; }
        public CarDescription Car { get; set; }
      
        public int Quantity { get; set; }
        public decimal RentalDuration { get; set; }
        public DateTime StartDate { get; set; }

    }
}