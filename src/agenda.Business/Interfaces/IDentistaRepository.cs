using agenda.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace agenda.Business.Interfaces
{
    public interface IDentistaRepository : IRepository<Dentista>
    {
        Task<Dentista> ObterDentista(Guid id);
        Task<IEnumerable<Dentista>> ObterDentistaConsulta();




    }
}
