namespace RepairShop.Core.Entities;

public class RepairPart
{ 
    public int Id { get; set; }
    public RepairRequest RepairRequest { get; set; }
    public int RepairRequestId { get; set; }
    public Part Part { get; set; }
    public int PartId { get; set; }
    public int Quantity { get; set; }
    
    public RepairPart(){}
}