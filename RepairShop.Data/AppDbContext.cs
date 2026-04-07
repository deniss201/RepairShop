using Microsoft.EntityFrameworkCore;
using RepairShop.Core.Entities;

namespace RepairShop.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Device> Devices { get; set; }
    public DbSet<Part> Parts { get; set; }
    public DbSet<RepairPart> RepairParts { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<RepairRequest> RepairRequests { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}