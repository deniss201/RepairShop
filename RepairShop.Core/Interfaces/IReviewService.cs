using RepairShop.Core.Entities;

namespace RepairShop.Core.Interfaces;

public interface IReviewService
{
    Review CreateReview(Review review);
    Review GetReviewByRepairRequestId(int requestId);
}