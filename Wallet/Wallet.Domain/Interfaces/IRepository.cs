namespace Wallet.Domain.Interfaces;

public interface IRepository<T> where T : EntityBase
{
    public Task<T> AddAsync(T entity);

    public Task<IEnumerable<T>> GetAllAsync();

    Task<ICollection<T>> GetAllIncludingAsync(params Expression<Func<T, object>>[] propertySelectors);

    Task<T?> GetByIdAsync(int id, bool asNoTracking = false);

    Task<T?> GetByAsync(params Expression<Func<T, bool>>[] predicates);

    Task<T?> GetByIdIncludingAsync(int id, params Expression<Func<T, object>>[] includeProperties);

    IQueryable<T> GetQuery();

    IQueryable<T> GetQueryIncluding(params Expression<Func<T, object>>[] includeProperties);

    public Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

    public Task<T> UpdateAsync(T entity);

    public Task RemoveAsync(T entity);
}