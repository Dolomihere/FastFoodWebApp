namespace Assignment_NET104.Models
{
    public enum OrderStatus
    {
        Pending = 1,
        Processing = 2,
        Completed = 3,
        Cancelled = 4,
    }

    public class Order
    {
        public int OrderId { get; set; }
        public string StreetAddress { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public OrderStatus Status { get; set; }

        // Relationship
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = new Customer();
        public List<OrderItem> OrderDetails { get; private set; } = new List<OrderItem>();
    }
}
