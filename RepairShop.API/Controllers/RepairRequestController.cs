using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepairShop.Core.Entities;
using RepairShop.Core.Enums;
using RepairShop.Core.Interfaces;
using RepairShop.API.DTO;

namespace RepairShop.API.Controllers;

[Authorize]
[ApiController]
[Route("api/RepairRequest")]
public class RepairRequestController : ControllerBase
{
    private readonly IRepairRequestService _repairRequestService;
    public RepairRequestController(IRepairRequestService repairRequestService)
    {
        _repairRequestService = repairRequestService;
    }

    [HttpGet("{id}")]
    public ActionResult<RepairRequest> GetRepairRequestById(int id)
    {
         return Ok((_repairRequestService.GetRepairRequestById(id)));
    }
    
    
    [HttpGet("")]
    public ActionResult<IEnumerable<RepairRequest>> GetAllRepairRequests()
    {
        return Ok(_repairRequestService.GetAllRepairRequests());
    }


    [HttpPost("")]
    public ActionResult<RepairRequest> CreateRepairRequest([FromBody] RepairRequest repairRequest)
    {
        return Ok(_repairRequestService.CreateRepairRequest(repairRequest));
    }

    
    [HttpGet("user/{userId}")]
    public ActionResult<IEnumerable<RepairRequest>> GetRepairRequestByUserId(int userId)
    {
        return Ok((_repairRequestService.GetRepairRequestByUserId(userId)));
    }

    [HttpPut("{id}/status")]
    [Authorize(Roles = "Admin")]
    public ActionResult UpdateStatus(int id, [FromBody] RepairStatus repairStatus)
    {
        _repairRequestService.UpdateStatus(id, repairStatus);
        return Ok();
    }

    [HttpPut("{id}/diagnosis-and-price")]
    [Authorize(Roles = "Admin")]
    public ActionResult SetDiagnosisAndPrice(int id, [FromBody] DiagnosisRequest request)
    {
        _repairRequestService.SetDiagnosisAndPrice(id, request.Diagnosis, request.Price);
        return Ok();
    }

}