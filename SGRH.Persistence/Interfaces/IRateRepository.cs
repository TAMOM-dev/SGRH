using System.Collections.Generic;
using System.Threading.Tasks;
using SGRH.Domain.Entities;

namespace SGRH.Persistence.Interfaces
{
    public interface IRateRepository
    {
        Task<List<Tarifa>> GetAllAsync();
        Task<Tarifa> GetByIdAsync(int id);
        Task AddAsync(Tarifa tarifa);
        Task UpdateAsync(Tarifa tarifa);
        Task DeleteAsync(Tarifa tarifa);
    }
}
