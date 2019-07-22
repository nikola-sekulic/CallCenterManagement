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
    public class DesignationRepository : IDesignationRepository
    {
        private readonly IApplicationDbContext _context;

        public DesignationRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Designations>> GetDesignationsAsync()
        {
            return await _context.Designations.ToListAsync();
        }

    }
}