using RepairShop.Core.Entities;

namespace RepairShop.Core.Interfaces;

public interface IUserService
{
    User RegisterUser(string email, string password, string firstName, string lastName, string phoneNumber);
    string LoginUser(string email, string password);
    User GetUserById(int id);
    List<User> GetUsers();
    
}