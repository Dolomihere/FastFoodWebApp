namespace Assignment_NET104.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total => Quantity * Price;
        public string FoodItemName { get; set; } = string.Empty;

        // Relationship
        public int OrderId { get; set; }
        public Order Order { get; set; } = new Order();
        public int FoodItemId { get; set; }
        public FoodItem FoodItem { get; set; } = new FoodItem();
    }
}
