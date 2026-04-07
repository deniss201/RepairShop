using RepairShop.Core.Entities;
using RepairShop.Core.Enums;

namespace RepairShop.Core.Interfaces;

public interface IRepairRequestService
{
    RepairRequest CreateRepairRequest(RepairRequest request);
    RepairRequest GetRepairRequestById(int id);
    List<RepairRequest> GetAllRepairRequests();
    List<RepairRequest> GetRepairRequestByUserId(int id);
    void UpdateStatus(int id, RepairStatus status);
    void SetDiagnosisAndPrice(int id,string diagnosis, decimal price);
    
}