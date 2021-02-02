using agenda.Business.Interfaces;
using agenda.Business.Models;
using agenda.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace agenda.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly MeuDbContext Db;
        protected readonly DbSet<TEntity> Dbset;

        protected Repository(MeuDbContext db)
        {
            Db = db;
            Dbset = db.Set<TEntity>();

        }


        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await Dbset.AsNoTracking().Where(predicate).ToListAsync();
        }

        public  virtual async Task Adicionar(TEntity entity)
        {
            Dbset.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            Dbset.Update(entity);
            await SaveChanges();
        }

        public virtual async Task<TEntity> ObterPorIf(Guid id)
        {
            return await Dbset.FindAsync(id);
           
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await Dbset.ToListAsync();

        }

        public virtual async Task Remover(Guid id)
        {
           
            Dbset.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public virtual async void Dispose()
        {
            Db?.Dispose();
        }
    }
}
