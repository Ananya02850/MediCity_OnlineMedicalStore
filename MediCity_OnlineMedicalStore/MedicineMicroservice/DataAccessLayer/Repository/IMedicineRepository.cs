using System.Collections.Generic;
using System.Threading.Tasks;
using MediCity_OnlineMedicalStore.MedicineMicroservice.DataAccessLayer.Models;

namespace MediCity_OnlineMedicalStore.MedicineMicroservice.DataAccessLayer.Repository
{
    public interface IMedicineRepository
    {
        Task<IEnumerable<Medicine>> GetAllMedicines();
        Task<Medicine> GetMedicineById(int id);
        Task AddMedicine(Medicine medicine);
        Task UpdateMedicine(Medicine medicine);
        Task DeleteMedicine(int id);
    }
}
