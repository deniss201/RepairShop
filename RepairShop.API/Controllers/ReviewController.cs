using Microsoft.AspNetCore.Mvc;
using RepairShop.Core.Entities;
using RepairShop.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace RepairShop.API.Controllers;


[ApiController]
[Route("api/Review")]

public class ReviewController: ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }
    
    [Authorize]
    [HttpPost("")]
    public ActionResult<Review> CreateReview([FromBody] Review review)
    {
       return Ok(_reviewService.CreateReview(review));
    }

    [HttpGet("repair/{requestId}")]
    public ActionResult<Review> GetReviewByRequestId(int requestId)
    {
        return Ok(_reviewService.GetReviewByRepairRequestId(requestId));
    }
    
    
    
}