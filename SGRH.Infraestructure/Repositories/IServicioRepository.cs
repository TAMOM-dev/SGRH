using SGRH.Infrastructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGRH.Infrastructure.Repositories
{
    public interface IServicioRepository
    {
        Task<List<Servicio>> GetAllAsync();
        Task<Servicio> GetByIdAsync(int id);
        Task AddAsync(Servicio servicio);
        Task UpdateAsync(Servicio servicio);
        Task DeleteAsync(Servicio servicio);
    }
}
