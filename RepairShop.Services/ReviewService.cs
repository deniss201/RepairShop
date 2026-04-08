using RepairShop.Core.Entities;
using RepairShop.Core.Interfaces;
using RepairShop.Data;

namespace RepairShop.Services;

public class ReviewService :IReviewService
{
    private readonly AppDbContext _context;

    public ReviewService(AppDbContext context)
    {
        _context = context;
    }

    public Review CreateReview(Review review)
    {
        _context.Reviews.Add(review);
        _context.SaveChanges();
        return review;
    }

    public Review GetReviewByRepairRequestId(int requestId)
    {
        var review = _context.Reviews.FirstOrDefault(r => r.RepairRequestId == requestId);
        if (review == null)
            throw new Exception("Invalid repair request");
        return review;
    }
}