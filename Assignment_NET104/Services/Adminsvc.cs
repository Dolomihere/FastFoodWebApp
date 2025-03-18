using Assignment_NET104.DataContext;
using Assignment_NET104.DTO;
using Assignment_NET104.Models;
using Assignment_NET104.Services.Interfaces;

namespace Assignment_NET104.Services
{
    public class Adminsvc : IAdmin
    {
        protected WebContext _context;
        public Adminsvc(WebContext context)
        {
            _context = context;
        }

        public void CreateNew(Admin user)
        {
            _context.Admins.Add(user);
            _context.SaveChanges();
        }

        public void Edit(Admin user)
        {
            var admin = _context.Admins.Find(user.AdminId);

            if (admin != null)
            {
                admin.Name = user.Name;
                admin.Email = user.Email;
                admin.Password = user.Password;

                _context.SaveChanges();
            }
        }

        public AdminDTO GetAdmin(int adminId)
        {
            var entity = _context.Admins.Find(adminId);

            if (entity != null)
            {
                return new AdminDTO()
                {
                    AdminId = entity.AdminId,
                    Name = entity.Name,
                    Email = entity.Email
                };
            }
            return new AdminDTO();
        }

        public void RemoveOther(int adminId)
        {
            var entity = _context.Admins.Find(adminId);

            if (entity != null)
            {
                _context.Admins.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
