namespace Assignment_NET104.Models
{
    public enum Categories
    {
        MonAn = 1,
        Combo = 2,
        Nuoc = 3,
        Khac = 4
    }

    public enum Status
    {
        Ready = 1,
        OutOfStock = 2
    }

    public class FoodItem
    {
        public int FoodItemId { get; set; }
        public string Name { get; set; } = string.Empty;
        public Categories Category { get; set; }
        public string? ImagePath { get; set; }
        public IFormFile? ImageFile { get; set; }
        public decimal Price { get; set; }
        public Status Status { get; set; }

        // Relationship
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        public ICollection<OrderItem> OrderDetails { get; set; } =  new List<OrderItem>();
    }
}
