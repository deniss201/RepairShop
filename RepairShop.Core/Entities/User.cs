using RepairShop.Core.Enums;

namespace RepairShop.Core.Entities;

public class User
{
    
    public int Id { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Role Role { get; set; }

    public User() {}
    
}