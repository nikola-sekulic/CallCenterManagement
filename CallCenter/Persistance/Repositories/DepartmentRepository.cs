using CallCenter.Core.Models;
using CallCenter.Core.Repositories;
using CallCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallCenter.Persistance.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IApplicationDbContext _context;

        public DepartmentRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Departments> GetDepartments()
        {
            return _context.Departments.ToList();
        }
    }
}