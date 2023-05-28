using System.Collections.Generic;
using System.Threading.Tasks;
using MediCity_OnlineMedicalStore.ReviewMicroservice.BusinessLayer.ModelDto;
using MediCity_OnlineMedicalStore.ReviewMicroservice.BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace MediCity_OnlineMedicalStore.ReviewMicroservice.Controller
{
    [ApiController]
    [Route("api/reviews")]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> GetAllReviews()
        {
            var reviews = await _reviewService.GetAllReviews();
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewDto>> GetReviewById(int id)
        {
            var review = await _reviewService.GetReviewById(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddReview(ReviewDto reviewDto)
        {
            var id = await _reviewService.AddReview(reviewDto);
            return CreatedAtAction(nameof(GetReviewById), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, ReviewDto reviewDto)
        {
            if (id != reviewDto.Id)
            {
                return BadRequest();
            }
            await _reviewService.UpdateReview(reviewDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            await _reviewService.DeleteReview(id);
            return NoContent();
        }
    }
}
