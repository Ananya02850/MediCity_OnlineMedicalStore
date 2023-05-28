namespace MediCity_OnlineMedicalStore.MedicineMicroservice.DataAccessLayer.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Manufacturer { get; set; }
        // Add more properties as needed
    }
}
