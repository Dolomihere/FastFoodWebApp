using Assignment_NET104.Models;

namespace Assignment_NET104.DTO
{
    public class FoodItemDTO
    {
        public int FoodItemId { get; set; }
        public string Name { get; set; } = string.Empty;
        public Categories Category { get; set; }
        public string? ImagePath { get; set; }
        public decimal Price { get; set; }
        public Status Status { get; set; }
    }
}
