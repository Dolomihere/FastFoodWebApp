namespace Assignment_NET104.DTO
{
    public class OrderItemDTO
    {
        public int FoodItemId { get; set; }
        public string FoodItemName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string? FoodItemImage { get; set; }
        public decimal Total => Quantity * Price;
    }
}
