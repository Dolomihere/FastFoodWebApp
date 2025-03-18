using Assignment_NET104.DTO;
using Assignment_NET104.Models;

namespace Assignment_NET104.Services.Interfaces
{
    public interface IAdmin
    {
        void CreateNew(Admin user);
        void Edit(Admin user);
        AdminDTO GetAdmin(int adminId);
        void RemoveOther(int adminId);
    }
}
