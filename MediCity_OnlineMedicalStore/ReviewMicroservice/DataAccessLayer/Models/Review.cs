using MediCity_OnlineMedicalStore.MedicineMicroservice.DataAccessLayer.Models;
using MediCity_OnlineMedicalStore.UserMicroservice.DataAccessLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace MediCity_OnlineMedicalStore.ReviewMicroservice.DataAccessLayer.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public int Rating { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }

        // Add more properties as needed
    }
}
