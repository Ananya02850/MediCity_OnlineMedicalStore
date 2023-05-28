using System.Collections.Generic;
using System.Threading.Tasks;
using MediCity_OnlineMedicalStore.ReviewMicroservice.DataAccessLayer.Models;

namespace MediCity_OnlineMedicalStore.ReviewMicroservice.DataAccessLayer.Repository
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetAllReviews();
        Task<Review> GetReviewById(int id);
        Task AddReview(Review review);
        Task UpdateReview(Review review);
        Task DeleteReview(int id);
    }
}
