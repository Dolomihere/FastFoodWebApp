using Assignment_NET104.DataContext;
using Assignment_NET104.DTO;
using Assignment_NET104.Models;
using Assignment_NET104.Services.Interfaces;

namespace Assignment_NET104.Services
{
    public class Customersvc : ICustomer
    {
        protected WebContext _context;
        public Customersvc(WebContext context)
        {
            _context = context;
        }

        public void CreateNew(Customer user)
        {
            if (user != null)
            {
                _context.Customers.Add(user);
                _context.SaveChanges();
            }
        }

        public void Edit(Customer user)
        {
            var customer = _context.Customers.Find(user.CustomerId);

            if (customer != null)
            {
                customer.Name = user.Name;
                customer.Email = user.Email;
                customer.Password = user.Password;
                customer.StreetAddress = user.StreetAddress;
                customer.City = user.City;

                _context.SaveChanges();
            }
        }

        public CustomerDTO GetUser(int userId)
        {
            var user = _context.Customers.Find(userId);

            if (user != null)
            {
                return new CustomerDTO
                {
                    CustomerId = userId,
                    Name = user.Name,
                    Email = user.Email,
                    StreetAddress = user.StreetAddress,
                    City = user.City,
                };
            }
            return new CustomerDTO();
        }

        public void RemoveUser(int userId)
        {
            var entity = _context.Customers.Find(userId);

            if (entity != null)
            {
                _context.Customers.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
