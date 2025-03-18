using Assignment_NET104.Models;

namespace Assignment_NET104.Services.Interfaces
{
    public interface IUser
    {
        UserRole ValidateUser(string username, string password);
    }
}
