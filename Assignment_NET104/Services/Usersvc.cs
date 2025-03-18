using Assignment_NET104.DataContext;
using Assignment_NET104.Models;
using Assignment_NET104.Services.Interfaces;

namespace Assignment_NET104.Services
{
    public class Usersvc : IUser
    {
        protected WebContext _context;
        public Usersvc(WebContext context)
        {
            _context = context;
        }

        public UserRole ValidateUser(string email, string password)
        {
            var foundAdmin = _context.Admins.Where(a => a.Email == email && a.Password == password).FirstOrDefault();
            var foundCustomer = _context.Customers.Where(c => c.Email == email && c.Password == password).FirstOrDefault();

            UserRole user = new UserRole();

            if (foundAdmin != null)
            {
                user.UserId = foundAdmin.AdminId;
                user.Name = foundAdmin.Name;
                user.Role = "Admin";
                return user;
            }
            else if (foundCustomer != null) 
            {
                user.UserId = foundCustomer.CustomerId;
                user.Name = foundCustomer.Name;
                user.Role = "Customer";
                return user;
            }
            return user;
        }
    }
}
