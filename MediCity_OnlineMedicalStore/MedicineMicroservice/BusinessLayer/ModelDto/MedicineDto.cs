namespace MediCity_OnlineMedicalStore.MedicineMicroservice.BusinessLayer.ModelDto
{
    public class MedicineDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Manufacturer { get; set; }
        // Add more properties as needed

        // Optional: You can include validation attributes for input validation
        // For example, to make a property required, you can use [Required] attribute from System.ComponentModel.DataAnnotations namespace:
        // [Required(ErrorMessage = "Name is required.")]
        // public string Name { get; set; }
    }
}
