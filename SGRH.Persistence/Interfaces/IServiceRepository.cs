using System.Collections.Generic;
using System.Threading.Tasks;
using SGRH.Domain.Entities;

namespace SGRH.Persistence.Interfaces
{
    public interface IServiceRepository
    {
        Task<List<Servicio>> GetAllAsync();
        Task<Servicio> GetByIdAsync(int id);
        Task AddAsync(Servicio servicio);
        Task UpdateAsync(Servicio servicio);
        Task DeleteAsync(Servicio servicio);
    }

    public class Servicio
    {
    }
}
