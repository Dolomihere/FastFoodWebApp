using Assignment_NET104.Models;
using System.ComponentModel.DataAnnotations;

namespace Assignment_NET104.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public string StreetAddress { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public OrderStatus Status { get; set; }
        public List<OrderItemDTO> Details { get; set; } = new List<OrderItemDTO>();
        public decimal Total => Details.Sum(d => d.Total);
    }
}
