using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SGRH.Domain.Entities;
using SGRH.Persistence.Interfaces;
using SGRH.Persistence.Context;

namespace SGRH.Persistence.Repositories
{
    public class RateRepository : IRateRepository
    {
        private readonly PersistenceContext _context;

        public RateRepository(PersistenceContext context)
        {
            _context = context;
        }

        public async Task<List<Tarifa>> GetAllAsync()
        {
            return await _context.Tarifas.ToListAsync();
        }

        public async Task<Tarifa> GetByIdAsync(int id)
        {
            return await _context.Tarifas.FindAsync(id);
        }

        public async Task AddAsync(Tarifa tarifa)
        {
            await _context.Tarifas.AddAsync(tarifa);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tarifa tarifa)
        {
            _context.Tarifas.Update(tarifa);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Tarifa tarifa)
        {
            _context.Tarifas.Remove(tarifa);
            await _context.SaveChangesAsync();
        }
    }
}
