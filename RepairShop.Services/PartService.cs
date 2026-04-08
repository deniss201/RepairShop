using RepairShop.Core.Entities;
using RepairShop.Core.Interfaces;
using RepairShop.Data;

namespace RepairShop.Services;

public class PartService : IPartService
{
    private readonly AppDbContext _context;

    public PartService(AppDbContext context)
    {
        _context = context;
    }

    public Part CreatePart(Part part)
    {
       _context.Parts.Add(part);
       _context.SaveChanges();
       return part;
    }

    public Part GetPartById(int id)
    {
        var part = _context.Parts.Find(id);
        if (part == null)
            throw new Exception("Part not found");
        return part;
    }

    public List<Part> GetParts()
    {
        return _context.Parts.ToList();
    }

    public void UpdateStock(int id, int quantity)
    {
        Part part = _context.Parts.Find(id);
        if (part == null)
            throw new Exception("Part not found");
        part.StockQuantity -= quantity;
        _context.SaveChanges();
    }
    
}