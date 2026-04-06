using RepairShop.Core.Enums;

namespace RepairShop.Core.Entities;

public class RepairRequest
{
    public int Id { get; set; }
    public User User { get; set; }
    public int UserId { get; set; }
    public Device Device { get; set; }
    public int DeviceId { get; set; }
    public string Diagnosis { get; set; }
    public decimal Price { get; set; }
    public RepairStatus Status { get; set; }
    public string Description { get; set; }
    public bool SkipApproval { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public RepairRequest(){}
    
}