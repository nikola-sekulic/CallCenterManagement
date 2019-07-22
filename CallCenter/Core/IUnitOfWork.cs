using CallCenter.Core.Repositories;

namespace CallCenter.Core
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employees { get; }
        IDepartmentRepository Departments { get; }
        IDesignationRepository Designations { get; }
        IReclamationRepository Reclamations { get; }
        ISoldDeviceRepository SoldDevices { get; }

        int Complete();
    }
}