using CallCenter.Core.Models;
using CallCenter.Core.Repositories;
using CallCenter.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CallCenter.Persistance.Repositories
{
    public class ReclamationRepository : IReclamationRepository
    {
        private readonly IApplicationDbContext _context;

        public ReclamationRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Reclamations reclamation)
        {
            _context.Reclamations.Add(reclamation);
        }

        public async Task<Reclamations> GetReclamationAsync(int id)
        {
            return await _context.Reclamations
               .Include(e => e.Specialist)
               .Include(e => e.SoldDevice)
               .Include(e => e.SoldDevice.Buyer)
               .Include(e => e.ReclamationType)
               .SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Reclamations>> GetReclamationsAsync()
        {
            return await _context.Reclamations
                .Include(e => e.SoldDevice)
                .Include(e => e.SoldDevice.Buyer)
                .Include(e => e.ReclamationType)
                .ToListAsync();
        }

        public void Remove(Reclamations reclamation)
        {
            _context.Reclamations.Remove(reclamation);
        }
    }
}