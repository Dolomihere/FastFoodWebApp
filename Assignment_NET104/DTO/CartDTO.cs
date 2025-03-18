namespace Assignment_NET104.DTO
{
    public class CartDTO
    {
        public int CartId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public List<CartItemDTO> Items { get; set; } = new List<CartItemDTO>();
    }
}
