using System.Collections.Generic;
using System.Threading.Tasks;
using MediCity_OnlineMedicalStore.MedicineMicroservice.BusinessLayer.ModelDto;

namespace MediCity_OnlineMedicalStore.MedicineMicroservice.BusinessLayer.Services
{
    public interface IMedicineService
    {
        Task<IEnumerable<MedicineDto>> GetAllMedicines();
        Task<MedicineDto> GetMedicineById(int id);
        Task<MedicineDto> AddMedicine(MedicineDto medicineDto);
        Task<MedicineDto> UpdateMedicine(int id, MedicineDto medicineDto);
        Task<bool> DeleteMedicine(int id);
    }
}
