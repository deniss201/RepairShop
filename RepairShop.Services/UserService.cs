using RepairShop.Core.Entities;
using RepairShop.Core.Interfaces;
using RepairShop.Data;

namespace RepairShop.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public User RegisterUser(string email, string password, string firstName, string lastName, string phoneNumber)
    {
        User user = new User();
        user.Email = email;
        user.PasswordHash = password; // TODO: hash this later
        user.FirstName = firstName;
        user.LastName = lastName;
        user.Phone = phoneNumber;
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }

    public string LoginUser(string email, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        if (user == null)
            throw new Exception("Invalid credentials");
        //TODO: verify password hash and generate JWT token later
        return "temp-token";
    }

    public User GetUserById(int id)
    {
        var user = _context.Users.Find(id);
        if(user == null)
            throw new Exception("User not found");
        return user;
    }

    public List<User> GetUsers()
    {
        return _context.Users.ToList();
    }
    
    
    
}