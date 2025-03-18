using Assignment_NET104.DataContext;
using Assignment_NET104.DTO;
using Assignment_NET104.Models;
using Assignment_NET104.Services.Interfaces;

namespace Assignment_NET104.Services
{
    public class Ordersvc : IOrder
    {
        protected WebContext _context;
        public Ordersvc(WebContext context)
        {
            _context = context;
        }

        public void AddNew(OrderItem item)
        {
            if (item != null)
            {
                _context.OrderDetails.Add(item);
                _context.SaveChanges();
            }
        }

        public void CreateNew(Order order)
        {
            if (order != null)
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
            }
        }

        public void Edit(Order order)
        {
            if (order != null)
            {
                var userOrder = _context.Orders.Find(order.OrderId);

                if (userOrder != null)
                {
                    userOrder.StreetAddress = order.StreetAddress;
                    userOrder.City = order.City;
                    userOrder.CreatedDate = order.CreatedDate;
                    userOrder.Status = order.Status;

                    _context.SaveChanges();
                }
            }
        }

        public void Edit(OrderItem item)
        {
            if (item != null)
            {
                var userOrderItem = _context.OrderDetails.Find(item.OrderItemId);

                if (userOrderItem != null)
                {
                    userOrderItem.FoodItemId = item.FoodItemId;
                    userOrderItem.FoodItemName = item.FoodItemName;
                    userOrderItem.Quantity = item.Quantity;
                    userOrderItem.Price = item.Price;

                    _context.SaveChanges();
                }
            }
        }

        public List<OrderItemDTO> GetList(int orderId)
        {
            var listItem = _context.OrderDetails.Where(od => od.OrderId == orderId);

            if (listItem != null)
            {
                List<OrderItemDTO> orderItems = new List<OrderItemDTO>();

                foreach (var item in listItem)
                {
                    orderItems.Add(new OrderItemDTO
                    {
                        FoodItemId = item.FoodItemId,
                        FoodItemName = item.FoodItemName,
                        Quantity = item.Quantity,
                        Price = item.Price
                    });
                }
                return orderItems;
            }
            return new List<OrderItemDTO>();
        }

        public OrderDTO GetOne(int orderId)
        {
            var order = _context.Orders.Find(orderId);

            if (order != null)
            {
                List<OrderItemDTO> orderItem = new List<OrderItemDTO>();

                foreach (var item in order.OrderDetails)
                {
                    orderItem.Add(new OrderItemDTO
                    {
                        FoodItemId = item.FoodItemId,
                        FoodItemName = item.FoodItemName,
                        Quantity = item.Quantity,
                        Price = item.Price
                    });
                }

                return new OrderDTO
                {
                    OrderId = order.OrderId,
                    StreetAddress = order.StreetAddress,
                    City = order.City,
                    CreatedDate = order.CreatedDate,
                    Status = order.Status,
                    Details = orderItem
                };
            }
            return new OrderDTO();
        }

        public List<OrderDTO> GetOrdersByCustomer(int customerId)
        {
            var order = _context.Orders.Where(o => o.CustomerId == customerId).ToList();

            if (order != null)
            {
                List<OrderDTO> orders = new List<OrderDTO>();

                foreach (var item in order)
                {
                    List<OrderItemDTO> orderItems = new List<OrderItemDTO>();

                    foreach (var orderItem in item.OrderDetails)
                    {
                        orderItems.Add(new OrderItemDTO
                        {
                            FoodItemId = orderItem.FoodItemId,
                            FoodItemName = orderItem.FoodItemName,
                            Quantity = orderItem.Quantity,
                            Price = orderItem.Price
                        });
                    }
                    orders.Add(new OrderDTO
                    {
                        OrderId = item.OrderId,
                        StreetAddress = item.StreetAddress,
                        City = item.City,
                        CreatedDate = item.CreatedDate,
                        Status = item.Status,
                        Details = orderItems
                    });
                }
                return orders;
            }
            return new List<OrderDTO>();
        }

        public void RemoveOrderDetail(int orderDetailId)
        {
            var item = _context.OrderDetails.Find(orderDetailId);

            if (item != null)
            {
                _context.OrderDetails.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}
