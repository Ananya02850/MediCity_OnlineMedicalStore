using System.Collections.Generic;
using System.Threading.Tasks;
using MediCity_OnlineMedicalStore.ReviewMicroservice.BusinessLayer.ModelDto;

namespace MediCity_OnlineMedicalStore.ReviewMicroservice.BusinessLayer.Services
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDto>> GetAllReviews();
        Task<ReviewDto> GetReviewById(int id);
        Task<int> AddReview(ReviewDto reviewDto);
        Task UpdateReview(ReviewDto reviewDto);
        Task DeleteReview(int id);
    }
}
