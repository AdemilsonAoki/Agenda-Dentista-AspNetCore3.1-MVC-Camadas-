using agenda.Business.Interfaces;
using agenda.Business.Models;
using agenda.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agenda.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {

        public ClienteRepository(MeuDbContext context) : base(context) { }

        public async Task<Cliente> ObterClienteEndereco(Guid id)
        {
            return await Db.Clientes.AsNoTracking().Include(e => e.Endereco).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Cliente> ObterConsultaPorClienteEndereco(Guid id)
        {
            return await Db.Clientes.AsNoTracking().Include(con => con.Consultas).Include(e => e.Endereco).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
