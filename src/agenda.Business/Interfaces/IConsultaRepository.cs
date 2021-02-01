using agenda.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace agenda.Business.Interfaces
{
    public interface IConsultaRepository : IRepository<Consulta>
    {
        Task<IEnumerable<Consulta>> ObterConsultaPorCliente(Guid clienteId);
        Task<IEnumerable<Consulta>> ObterConsultaPorDentista(Guid dentistaId);

        Task<Consulta> ObterConsultaDentistaCliente(Guid id);
    }
}
