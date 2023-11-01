namespace ProjectPartB.Models
{
    public class CartItem
    {
        public int UserId { get; set; }
        public AspNetUser AspNetUser { get; set; }
        public int CarDescriptionId { get; set; }
        public CarDescription Car { get; set; }
      
        public int Quantity { get; set; }
        public decimal RentalDuration { get; set; }
        public DateTime StartDate { get; set; }

    }
}