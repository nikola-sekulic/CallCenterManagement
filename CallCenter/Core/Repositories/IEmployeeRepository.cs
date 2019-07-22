using CallCenter.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter.Core.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employees>> GetEmployeesAsync();
        IEnumerable<Employees> GetActiveSpecialists(string query);
        Employees GetEmployee(int id);
        Employees GetAgent(int agentId);
        void Add(Employees supervisor);
        void Remove(Employees employeeInDb);
        Task<IEnumerable<Employees>> GetSupervisorAsync();
    }
}
