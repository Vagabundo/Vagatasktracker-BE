using Microsoft.EntityFrameworkCore;
using TaskTracker.Domain;
using TaskTracker.Application.Interfaces;

namespace TaskTracker.Database;

public abstract class RepositoryBase<TEntity, TContext> : IRepository<TEntity>
    where TEntity : class, IEntity
    where TContext : DbContext
{
    private readonly TContext context;
    public RepositoryBase(TContext context)
    {
        this.context = context;
    }
    
    public async Task<TEntity> Add(TEntity entity)
    {
        context.Set<TEntity>().Add(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> Delete(Guid id)
    {
        var entity = await context.Set<TEntity>().FindAsync(id);
        if (entity == null)
        {
            return entity;
        }

        //context.Set<TEntity>().Remove(entity);
        entity.IsDeleted = true;
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<TEntity> Get(Guid id)
    {
        return await context.Set<TEntity>().FindAsync(id);
    }

    public async Task<List<TEntity>> GetAll()
    {
        return await context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity> Update(TEntity entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return entity;
    }
}
