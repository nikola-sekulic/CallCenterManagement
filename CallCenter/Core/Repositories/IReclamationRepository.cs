using CallCenter.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter.Core.Repositories
{
    public interface IReclamationRepository
    {
        Task<IEnumerable<Reclamations>> GetReclamationsAsync();
        Task<Reclamations> GetReclamationAsync(int id);
        void Add(Reclamations reclamation);
        void Remove(Reclamations sreclamation);
    }
}
