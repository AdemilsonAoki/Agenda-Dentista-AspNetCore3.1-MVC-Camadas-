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
    public class DentistaRepository : Repository<Dentista>, IDentistaRepository
    {

        public DentistaRepository(MeuDbContext context) : base(context) {  }

     

        public async Task<Dentista> ObterDentista(Guid id)
        {
            return await Db.Dentistas.AsNoTracking().FirstOrDefaultAsync(d => d.Id == id);
        }

   
        public async  Task<Dentista> ObterDentistaConsulta(Guid id)
        {
            return await Db.Dentistas.AsNoTracking().Include(con => con.Consultas).FirstOrDefaultAsync(d => d.Id == id);

        }
    }
}
