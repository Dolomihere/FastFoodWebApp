namespace Assignment_NET104.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public string? SessionId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        // Relationship
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public ICollection<CartItem> CartItems { get; private set; } = new List<CartItem>();
    }
}
