namespace ProjectPartB.Models
{
    public class UserCartViewModel
    {
        public string FullName { get; set; }  // From the AspNetUser table
        public string DriverLicense { get; set; }  // From the AspNetUser table
        public List<CartDetailsViewModel> CartItems { get; set; }  // Details for each cart item
    }

    public class CartDetailsViewModel
    {
        public int CarId { get; set; }  // From the CarDescription table
        public decimal RentalDuration { get; set; }  // From the CarDescription table
        public int Quantity { get; set; }  // From the CartItem table
        public DateTime StartDate { get; set; }  // From the CartItem table
    }
}