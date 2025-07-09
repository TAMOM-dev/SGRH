using SGRH.Application.Contracts.Services;
using SGRH.Application.Dtos.Servicio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGRH.Application.Services.Servicio
{
    public class ServicioService : IServicioService
    {
        // Aquí irá tu lógica más adelante cuando conectemos con infraestructura
        public async Task<List<ServicioDto>> GetAllAsync()
        {
            // Ejemplo básico de retorno estático
            return new List<ServicioDto>
            {
                new ServicioDto { Id = 1, Nombre = "Spa", Precio = 100.00m },
                new ServicioDto { Id = 2, Nombre = "Piscina", Precio = 50.00m }
            };
        }

        public async Task<ServicioDto> GetByIdAsync(int id)
        {
            return new ServicioDto { Id = id, Nombre = "Ejemplo", Precio = 99.99m };
        }

        public async Task CreateAsync(CreateServicioDto dto)
        {
            // Aquí iría la lógica para crear un servicio
        }

        public async Task UpdateAsync(int id, UpdateServicioDto dto)
        {
            // Aquí iría la lógica para actualizar un servicio
        }

        public async Task DeleteAsync(int id)
        {
            // Aquí iría la lógica para eliminar un servicio
        }
    }
}
