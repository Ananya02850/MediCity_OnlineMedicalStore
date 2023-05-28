using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediCity_OnlineMedicalStore.ReviewMicroservice.BusinessLayer.ModelDto;
using MediCity_OnlineMedicalStore.ReviewMicroservice.DataAccessLayer.Models;
using MediCity_OnlineMedicalStore.ReviewMicroservice.DataAccessLayer.Repository;

namespace MediCity_OnlineMedicalStore.ReviewMicroservice.BusinessLayer.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewService(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReviewDto>> GetAllReviews()
        {
            var reviews = await _reviewRepository.GetAllReviews();
            return _mapper.Map<IEnumerable<ReviewDto>>(reviews);
        }

        public async Task<ReviewDto> GetReviewById(int id)
        {
            var review = await _reviewRepository.GetReviewById(id);
            return _mapper.Map<ReviewDto>(review);
        }

        public async Task<int> AddReview(ReviewDto reviewDto)
        {
            var review = _mapper.Map<Review>(reviewDto);
            await _reviewRepository.AddReview(review);
            return review.Id;
        }

        public async Task UpdateReview(ReviewDto reviewDto)
        {
            var review = _mapper.Map<Review>(reviewDto);
            await _reviewRepository.UpdateReview(review);
        }

        public async Task DeleteReview(int id)
        {
            await _reviewRepository.DeleteReview(id);
        }
    }
}
