using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepairShop.Core.Entities;
using RepairShop.Core.Interfaces;

namespace RepairShop.API.Controllers;

[Authorize(Roles = "Admin")]
[ApiController]
[Route("api/Part")]

public class PartController: ControllerBase
{
    private readonly IPartService _partService;

    public PartController(IPartService partService)
    {
        _partService = partService;
    }

    [HttpPost("")]
    public ActionResult<Part> CreatePart([FromBody] Part part)
    {
        return Ok(_partService.CreatePart(part));
    }

    [HttpGet("{id}")]
    public ActionResult<Part> GetPartById(int id)
    {
        return Ok(_partService.GetPartById(id));
    }

    [HttpGet("")]
    public ActionResult<IEnumerable<Part>> GetParts()
    {
        return Ok(_partService.GetParts());
    }

    [HttpPut("{id}/stock")]
    public ActionResult UpdateStock(int id, [FromBody] int quantity)
    {
        _partService.UpdateStock(id, quantity);
        return Ok();
    }
    
}