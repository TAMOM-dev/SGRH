using SGRH.Application.Dtos.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGRH.Application.Contracts.Services
{
    public interface IServicioService
    {
        Task<List<ServicioDto>> GetAllAsync();
        Task<ServicioDto> GetByIdAsync(int id);
        Task CreateAsync(CreateServicioDto dto);
        Task UpdateAsync(int id, UpdateServicioDto dto);
        Task DeleteAsync(int id);
    }
}
