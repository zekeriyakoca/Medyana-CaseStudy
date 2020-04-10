using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Medyana.Domain.Interface;
using Medyana.Infrastructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace Medyana.Infrastructure.Repositories
{
  public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
  {
    protected readonly DataContext Context;

    public Repository(DataContext context)
    {
      Context = context;
    }

    public async Task<TEntity> Get(int id)
    {
      return await Context.Set<TEntity>().FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
      return await Context.Set<TEntity>().AsNoTracking().ToListAsync();
    }

    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
      return Context.Set<TEntity>().Where(predicate);
    }

    public async Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
    {
      return await Context.Set<TEntity>().SingleOrDefaultAsync(predicate);
    }

    public void Add(TEntity entity)
    {
      Context.Set<TEntity>().Add(entity);
    }
    public void Update(TEntity entity)
    {
      Context.Set<TEntity>().Update(entity);
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
      Context.Set<TEntity>().AddRange(entities);
    }

    public void Remove(TEntity entity)
    {
      Context.Set<TEntity>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
      Context.Set<TEntity>().RemoveRange(entities);
    }

    public void Attach(TEntity entity)
    {
      Context.Attach(entity);
    }

    public int SaveChanges()
    {
      return Context.SaveChanges();
    }
    public async Task<int> SaveChangesAsync()
    {
      return await Context.SaveChangesAsync();
    }
  }
}
