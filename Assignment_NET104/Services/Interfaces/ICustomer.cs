using Assignment_NET104.DTO;
using Assignment_NET104.Models;

namespace Assignment_NET104.Services.Interfaces
{
    public interface ICustomer
    {
        void CreateNew(Customer user);
        void Edit(Customer user);
        CustomerDTO GetUser(int userId);
        void RemoveUser(int userId);
    }
}
