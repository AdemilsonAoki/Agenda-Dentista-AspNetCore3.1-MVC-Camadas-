using agenda.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace agenda.Business.Interfaces
{
    public interface IEnderecoRepository: IRepository<Endereco>
    {

        Task<Endereco> ObterEnderecoPorCliente(Guid clienteId);
    }
}
