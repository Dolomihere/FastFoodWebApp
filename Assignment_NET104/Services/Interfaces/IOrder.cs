using Assignment_NET104.DTO;
using Assignment_NET104.Models;

namespace Assignment_NET104.Services.Interfaces
{
    public interface IOrder
    {
        //For creation
        void CreateNew(Order order);

        //For user side
        void Edit(Order order);
        List<OrderDTO> GetOrdersByCustomer(int customerId);
        OrderDTO GetOne(int orderId);

        void AddNew(OrderItem item);
        void Edit(OrderItem item);
        List<OrderItemDTO> GetList(int orderId);
        void RemoveOrderDetail(int orderDetailId);
    }
}
