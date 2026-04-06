namespace RepairShop.Core.Entities;

public class Part
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    
    public Part(){}
}