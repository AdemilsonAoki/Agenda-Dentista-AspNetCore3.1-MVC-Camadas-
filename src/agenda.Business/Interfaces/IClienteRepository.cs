using agenda.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace agenda.Business.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente> ObterClienteEndereco(Guid id);

        Task<Cliente> ObterConsultaPorClienteEndereco(Guid Id);



    }
}
