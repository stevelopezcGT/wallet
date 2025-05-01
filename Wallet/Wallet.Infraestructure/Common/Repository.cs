namespace Wallet.Infrastructure.Common;

public class Repository<T> : IRepository<T> where T : EntityBase
{
    private readonly AppDbContext _appDbContext;

    public Repository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<T> AddAsync(T entity)
    {
        await _appDbContext.Set<T>().AddAsync(entity);
        await _appDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _appDbContext.Set<T>().Where(predicate).ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _appDbContext.Set<T>().ToListAsync();
    }

    public virtual async Task<ICollection<T>> GetAllIncludingAsync(params Expression<Func<T, object>>[] propertySelectors)
    {
        var query = _appDbContext.Set<T>().AsQueryable();

        foreach (var selector in propertySelectors)
        {
            query = query.Include(selector);
        }

        return await query.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id, bool asNoTracking = false)
    {
        var dbSet = _appDbContext.Set<T>();

        var query = asNoTracking ? dbSet.AsNoTracking() : dbSet;

        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }

    public virtual async Task<T?> GetByAsync(params Expression<Func<T, bool>>[] predicates)
    {
        if (predicates == null || predicates.Length == 0)
        {
            throw new ArgumentException("At least one predicate is required.", nameof(predicates));
        }

        var combinedPredicate = predicates[0];

        for (int i = 1; i < predicates.Length; i++)
        {
            combinedPredicate = CombinePredicates(combinedPredicate, predicates[i]);
        }

        return await _appDbContext.Set<T>()
            .AsQueryable()
            .FirstOrDefaultAsync(combinedPredicate);
    }

    private static Expression<Func<T, bool>> CombinePredicates(Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
    {
        var parameter = Expression.Parameter(typeof(T), "x");
        var body = Expression.AndAlso(
            Expression.Invoke(first, parameter),
            Expression.Invoke(second, parameter)
        );
        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }

    public virtual async Task<T?> GetByIdIncludingAsync(int id, params Expression<Func<T, object>>[] includeProperties)
    {
        var query = _appDbContext.Set<T>().AsQueryable();

        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }

        return await query.FirstOrDefaultAsync(entity => entity.Id.Equals(id));
    }

    public IQueryable<T> GetQuery()
    {
        return _appDbContext.Set<T>().AsQueryable();
    }

    public IQueryable<T> GetQueryIncluding(params Expression<Func<T, object>>[] includeProperties)
    {
        var query = _appDbContext.Set<T>().AsQueryable();

        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }

        return query;
    }

    public async Task RemoveAsync(T entity)
    {
        _appDbContext.Set<T>().Remove(entity!);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<T> UpdateAsync(T entity)
    {
        var trackedEntity = _appDbContext.Set<T>().Local.FirstOrDefault(e => e.Id == entity.Id);
        if (trackedEntity != null)
        {
            _appDbContext.Entry(trackedEntity).CurrentValues.SetValues(entity);
        }
        else
        {
            _appDbContext.Set<T>().Update(entity);
        }

        await _appDbContext.SaveChangesAsync();
        return entity;
    }
}