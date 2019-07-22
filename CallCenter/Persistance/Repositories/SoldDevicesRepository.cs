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
    public class SoldDevicesRepository : ISoldDeviceRepository
    {
        private readonly IApplicationDbContext _context;

        public SoldDevicesRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SoldDevices>> GetSoldDevicesAsync()
        {
            return await _context.SoldDevices.ToListAsync();
        }

        public async Task<SoldDevices> GetSoldDeviceAsync(int id)
        {
            return await _context.SoldDevices.SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}