namespace Assignment_NET104.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public string FoodItemName { get; set; } = string.Empty;
        public string? FoodItemImage { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        // Relationship
        public int CartId { get; set; }
        public Cart Cart { get; set; } = new Cart();
        public int FoodItemId { get; set; }
        public FoodItem FoodItem { get; set; } = new FoodItem();
    }
}
