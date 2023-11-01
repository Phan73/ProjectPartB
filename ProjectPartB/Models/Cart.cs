namespace ProjectPartB.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddItem(CarDescription car, int additionalDuration = 1)
        {
            var existingItem = Items.FirstOrDefault(i => i.CarDescriptionId == car.CarDescriptionId);
            if (existingItem == null)
            {
                Items.Add(new CartItem
                {
                    Car = car,
                    CarDescriptionId = car.CarDescriptionId,
                    RentalDuration = additionalDuration
                });
            }
            else
            {
                existingItem.RentalDuration += additionalDuration;
            }
        }

        public void RemoveItem(int carDescriptionId)
        {
            var itemToRemove = Items.FirstOrDefault(i => i.CarDescriptionId == carDescriptionId);
            if (itemToRemove != null)
            {
                Items.Remove(itemToRemove);
            }
        }

        public void Clear()
        {
            Items.Clear();
        }

        public decimal CalculateTotalCost()
        {
            decimal totalCost = 0;
            foreach (var item in Items)
            {
                totalCost += item.Car.RatePerDay * item.RentalDuration;
            }
            return totalCost;
        }
    }
}