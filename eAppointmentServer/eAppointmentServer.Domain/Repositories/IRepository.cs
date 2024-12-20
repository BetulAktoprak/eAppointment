using System.Linq.Expressions;

namespace eAppointmentServer.Domain.Repositories;
public interface IRepository<T> where T : class
{
    IQueryable<T> GetAll();
    IQueryable<T> Where(Expression<Func<T, bool>> expression);
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    void Update(T entity);
    Task DeleteByIdAsync(string id);
    void Delete(T entity);
}
