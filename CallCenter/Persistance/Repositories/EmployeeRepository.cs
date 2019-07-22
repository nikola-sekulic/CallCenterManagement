using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using CallCenter.Core.Models;
using CallCenter.Core.Repositories;
using CallCenter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CallCenter.Persistance.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IApplicationDbContext _context;

        public EmployeeRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Employees supervisor)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employees> GetActiveSpecialists(string query)
        {
            throw new NotImplementedException();
        }

        public Employees GetAgent(int agentId)
        {
            throw new NotImplementedException();
        }

        public Employees GetEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employees>> GetEmployeesAsync()
        {
            return await _context.Employees
                .Include(e => e.Designation)
                .Include(e => e.Department)
                .ToListAsync();
        }

        public Task<IEnumerable<Employees>> GetSupervisorAsync()
        {
            throw new NotImplementedException();
        }

        public void Remove(Employees employeeInDb)
        {
            throw new NotImplementedException();
        }
    }
}