using agenda.Business.Interfaces;
using agenda.Business.Models;
using agenda.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace agenda.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {

        public EnderecoRepository(MeuDbContext context) : base(context)
        {

        }

        public async Task<Endereco> ObterEnderecoPorCliente(Guid clienteId)
        {
            return await Db.Enderecos.AsTracking().Include(c => c.Cliente).FirstOrDefaultAsync(e => e.Id == clienteId);
        }
    }
}
