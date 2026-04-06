namespace RepairShop.Core.Entities;

public class Review
{
    public int Id { get; set; }
    public User User { get; set; }
    public int UserId { get; set; }
    public RepairRequest RepairRequest { get; set; }
    public int RepairRequestId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public Review() { }
}