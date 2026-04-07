using Microsoft.EntityFrameworkCore;
using RepairShop.Core.Entities;
using RepairShop.Core.Enums;
using RepairShop.Core.Interfaces;
using RepairShop.Data;

namespace RepairShop.Services;

public class RepairRequestService : IRepairRequestService
{
    private readonly AppDbContext _context;

    public RepairRequestService(AppDbContext context)
    {
        _context = context;
    }

    public RepairRequest CreateRepairRequest(RepairRequest request)
    {
        _context.RepairRequests.Add(request);
        _context.SaveChanges();
        return request;
    }

    public RepairRequest GetRepairRequestById(int id)
    {
        var repairRequest = _context.RepairRequests.Find(id);
        if (repairRequest == null)
            throw new Exception("Repair request not found");
        return repairRequest;
    }

    public List<RepairRequest> GetAllRepairRequests()
    {
        return _context.RepairRequests.ToList();
    }

    public List<RepairRequest> GetRepairRequestByUserId(int id)
    {
        return _context.RepairRequests.Where(x => x.UserId == id).ToList();
    }

    public void UpdateStatus(int id, RepairStatus status)
    {
        RepairRequest repairRequest = _context.RepairRequests.Find(id);
        if (repairRequest == null)
            throw new Exception("Repair request not found");
        repairRequest.Status = status;
        _context.SaveChanges();
    }

    public void SetDiagnosisAndPrice(int id, string diagnosis, decimal price)
    {
        RepairRequest repairRequest = _context.RepairRequests.Find(id);
        if (repairRequest == null)
            throw new Exception("Repair request not found");
        repairRequest.Diagnosis = diagnosis;
        repairRequest.Price = price;
        _context.SaveChanges();
    }
    
}