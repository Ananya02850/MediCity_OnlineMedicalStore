using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediCity_OnlineMedicalStore.MedicineMicroservice.DataAccessLayer.Data;
using MediCity_OnlineMedicalStore.MedicineMicroservice.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace MediCity_OnlineMedicalStore.MedicineMicroservice.DataAccessLayer.Repository
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MedicineRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Medicine>> GetAllMedicines()
        {
            return await _dbContext.Medicines.ToListAsync();
        }

        public async Task<Medicine> GetMedicineById(int id)
        {
            return await _dbContext.Medicines.FindAsync(id);
        }

        public async Task AddMedicine(Medicine medicine)
        {
            _dbContext.Medicines.Add(medicine);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateMedicine(Medicine medicine)
        {
            _dbContext.Entry(medicine).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteMedicine(int id)
        {
            var medicine = await _dbContext.Medicines.FindAsync(id);
            if (medicine != null)
            {
                _dbContext.Medicines.Remove(medicine);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
