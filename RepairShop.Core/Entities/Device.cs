namespace RepairShop.Core.Entities;

public class Device
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public RepairRequest RepairRequest { get; set; }
    public int RepairRequestId { get; set; }
    
    public Device(){}
    
}