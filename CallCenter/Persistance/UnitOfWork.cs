using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CallCenter.Core;
using CallCenter.Core.Models;
using CallCenter.Core.Repositories;
using CallCenter.Persistance.Repositories;

namespace CallCenter.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CallCenterContext _context;
        public IEmployeeRepository Employees { get; private set; }
        public IDepartmentRepository Departments { get; private set; }
        public IDesignationRepository Designations { get; private set; }
        public IReclamationRepository Reclamations { get; private set; }
        public ISoldDeviceRepository SoldDevices { get; private set; }

        public UnitOfWork(CallCenterContext context)
        {
            _context = context;
            Employees = new EmployeeRepository(_context);
            Designations = new DesignationRepository(_context);
            Reclamations = new ReclamationRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

       

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}