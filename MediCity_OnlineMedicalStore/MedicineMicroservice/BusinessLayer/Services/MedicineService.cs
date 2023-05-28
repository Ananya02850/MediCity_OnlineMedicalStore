using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediCity_OnlineMedicalStore.MedicineMicroservice.BusinessLayer.ModelDto;

namespace MediCity_OnlineMedicalStore.MedicineMicroservice.BusinessLayer.Services
{
    public class MedicineService : IMedicineService
    {
        // This is just a sample implementation. You would typically use a database or external API for data storage and retrieval.

        private readonly List<MedicineDto> _medicines = new List<MedicineDto>();

        public MedicineService()
        {
            // Initialize with some sample data for demonstration purposes
            _medicines.Add(new MedicineDto { Id = 1, Name = "Medicine 1", Description = "Sample description 1", Price = 9.99m, Quantity = 10, Manufacturer = "Manufacturer A" });
            _medicines.Add(new MedicineDto { Id = 2, Name = "Medicine 2", Description = "Sample description 2", Price = 19.99m, Quantity = 5, Manufacturer = "Manufacturer B" });
            _medicines.Add(new MedicineDto { Id = 3, Name = "Medicine 3", Description = "Sample description 3", Price = 14.99m, Quantity = 8, Manufacturer = "Manufacturer C" });
        }

        public Task<IEnumerable<MedicineDto>> GetAllMedicines()
        {
            return Task.FromResult<IEnumerable<MedicineDto>>(_medicines);
        }

        public Task<MedicineDto> GetMedicineById(int id)
        {
            var medicine = _medicines.Find(m => m.Id == id);
            return Task.FromResult(medicine);
        }

        public Task<MedicineDto> AddMedicine(MedicineDto medicineDto)
        {
            medicineDto.Id = GenerateNewId();
            _medicines.Add(medicineDto);
            return Task.FromResult(medicineDto);
        }

        public Task<MedicineDto> UpdateMedicine(int id, MedicineDto medicineDto)
        {
            var existingMedicine = _medicines.Find(m => m.Id == id);
            if (existingMedicine == null)
            {
                throw new ArgumentException("Medicine not found.");
            }

            existingMedicine.Name = medicineDto.Name;
            existingMedicine.Description = medicineDto.Description;
            existingMedicine.Price = medicineDto.Price;
            existingMedicine.Quantity = medicineDto.Quantity;
            existingMedicine.Manufacturer = medicineDto.Manufacturer;

            return Task.FromResult(existingMedicine);
        }

        public Task<bool> DeleteMedicine(int id)
        {
            var existingMedicine = _medicines.Find(m => m.Id == id);
            if (existingMedicine == null)
            {
                throw new ArgumentException("Medicine not found.");
            }

            _medicines.Remove(existingMedicine);
            return Task.FromResult(true);
        }

        private int GenerateNewId()
        {
            // Generate a new unique id based on your requirements
            // This is just a sample implementation
            return _medicines.Count + 1;
        }
    }
}
