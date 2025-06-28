using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SGRH.Domain.Entities;
using SGRH.Persistence.Interfaces;
using SGRH.Persistence.Context;

namespace SGRH.Persistence.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly PersistenceContext _context;

        public ServiceRepository(PersistenceContext context)
        {
            _context = context;
        }

        public async Task<List<Service>> GetAllAsync()
        {
            return await _context.Servicios.ToListAsync();
        }

        public async Task<Service> GetByIdAsync(int id)
        {
            return await _context.Servicios.FindAsync(id);
        }

        public async Task AddAsync(Servicio servicio)
        {
            await _context.Servicios.AddAsync(servicio);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Servicio servicio)
        {
            _context.Servicios.Update(servicio);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Servicio servicio)
        {
            _context.Servicios.Remove(servicio);
            await _context.SaveChangesAsync();
        }

        Task<List<Servicio>> IServiceRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Servicio> IServiceRepository.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }

    public class Service
    {
    }
}
