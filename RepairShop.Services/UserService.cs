using Microsoft.Extensions.Configuration;
using RepairShop.Core.Entities;
using RepairShop.Core.Interfaces;
using RepairShop.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace RepairShop.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public UserService(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }
    
    

    public User RegisterUser(string email, string password, string firstName, string lastName, string phoneNumber)
    {
        User user = new User();
        user.Email = email;
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
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
        if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            throw new Exception("Invalid credentials");
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(24),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
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