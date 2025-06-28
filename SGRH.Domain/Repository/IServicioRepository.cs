using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGRH.Domain.Entities;

namespace SGRH.Domain.Repository
{
    public interface IServicioRepository
    {
        Task<IEnumerable<Servicio>> ObtenerTodos();
        Task<Servicio?> ObtenerPorId(int id);
        Task Crear(Servicio servicio);
        Task Actualizar(Servicio servicio);
        Task Eliminar(int id);
    }
}
