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
    public class ConsultaRepository : Repository<Consulta>, IConsultaRepository
    {
        public ConsultaRepository(MeuDbContext context) : base(context) { }

        public async Task<Consulta> ObterConsultaDentistaCliente(Guid id)
        {
            return await Db.Consultas.AsNoTracking().Include(c => c.Cliente).Include(d => d.Dentista)
                .FirstOrDefaultAsync(con => con.Id == id);

        }

        public async Task<IEnumerable<Consulta>> ObterConsultaPorCliente(Guid clienteId)
        {
            return await Buscar(con => con.ClienteId == clienteId);

        }

        public async Task<IEnumerable<Consulta>> ObterConsultaPorDentista(Guid dentistaId)
        {
            return await Buscar(con => con.DentistaId == dentistaId);

        }

        public async Task<IEnumerable<Consulta>> ObterDentistaClienteAgenda()
        {
            return await Db.Consultas.AsNoTracking().Include(c => c.Cliente).Include(d => d.Dentista)
               .OrderBy(con => con.DataConsulta).ToListAsync();
        }
    }
}
