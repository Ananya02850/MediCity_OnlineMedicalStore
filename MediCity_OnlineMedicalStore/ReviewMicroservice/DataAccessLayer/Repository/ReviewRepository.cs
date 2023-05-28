using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediCity_OnlineMedicalStore.ReviewMicroservice.DataAccessLayer.Data;
using MediCity_OnlineMedicalStore.ReviewMicroservice.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace MediCity_OnlineMedicalStore.ReviewMicroservice.DataAccessLayer.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ReviewRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Review>> GetAllReviews()
        {
            return await _dbContext.Reviews.ToListAsync();
        }

        public async Task<Review> GetReviewById(int id)
        {
            return await _dbContext.Reviews.FindAsync(id);
        }

        public async Task AddReview(Review review)
        {
            _dbContext.Reviews.Add(review);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateReview(Review review)
        {
            _dbContext.Entry(review).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteReview(int id)
        {
            var review = await _dbContext.Reviews.FindAsync(id);
            if (review != null)
            {
                _dbContext.Reviews.Remove(review);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
