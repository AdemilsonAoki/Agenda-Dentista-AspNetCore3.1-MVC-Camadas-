using agenda.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace agenda.Business.Interfaces
{
    interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente> ObterClienteEndereco(Guid id);

        Task<IEnumerable<Consulta>> ObterConsultaPorCliente(Guid clienteId);


    }
}
