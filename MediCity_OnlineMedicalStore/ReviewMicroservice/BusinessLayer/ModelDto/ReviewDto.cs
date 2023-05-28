namespace MediCity_OnlineMedicalStore.ReviewMicroservice.BusinessLayer.ModelDto
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public int UserId { get; set; }
        public int MedicineId { get; set; }
        // Add more properties as needed
    }
}
