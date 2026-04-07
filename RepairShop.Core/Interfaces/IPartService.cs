using RepairShop.Core.Entities;

namespace RepairShop.Core.Interfaces;

public interface IPartService
{
    Part CreatePart(Part part);
    Part GetPartById(int id);
    List<Part> GetParts();
    void UpdateStock(int id, int quantity);
}