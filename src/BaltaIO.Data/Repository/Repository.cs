using BaltaIO.Business.Interface;
using BaltaIO.Business.Models;
using BaltaIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BaltaIO.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly BaltaDbContext _dbContext;
        protected readonly DbSet<TEntity> _Dbset;

        public Repository(BaltaDbContext db)
        {
            _dbContext = db;
            _Dbset = db.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await _Dbset.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(int id)
        {
            return await _Dbset.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await _Dbset.ToListAsync();
        }
        public virtual async Task Adicionar(TEntity entity)
        {
            _dbContext.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            _dbContext.Update(entity);
            await SaveChanges();
        }
        public async Task Remover(int id)
        {
            _Dbset.Remove(await _Dbset.FindAsync(id));
            await SaveChanges();

        }

        public async Task<int> SaveChanges()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
