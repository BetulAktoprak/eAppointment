using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eAppointmentServer.Domain.Repositories;
public class Repository<T, TContext> : IRepository<T>
    where T : class
    where TContext : DbContext
{
    private readonly TContext _context;
    private DbSet<T> _dbSet;
    public Repository(TContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task DeleteByIdAsync(string id)
    {
        T? entity = await _dbSet.FindAsync(id);
        if (entity is not null)
        {
            _dbSet.Remove(entity);
        }
    }

    public IQueryable<T> GetAll()
    {
        return _dbSet.AsNoTracking().AsQueryable();
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> expression)
    {
        return _dbSet.AsNoTracking().Where(expression).AsQueryable();
    }
}
