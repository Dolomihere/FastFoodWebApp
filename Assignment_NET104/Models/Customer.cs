namespace Assignment_NET104.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string CheckPassword { get; set; } = string.Empty;
        public string StreetAddress { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

        // Relationship
        public Cart Cart { get; set; } = new Cart();
        public ICollection<Order> Orders { get; private set; } = new List<Order>();
    }
}
