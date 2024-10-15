using System;
using System.Linq.Expressions;
using Ordering.Core.Common;

namespace Ordering.Core.Repositories;

public interface IAsyncRepository<T> where T : EntityBase
{
    Task<T> GetAllAsync();
    Task<IReadOnlyList<T>> GetAllAsync(Expression<Predicate<T>> predicate);
    Task<T> GetByIdAsync(int id);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);    

}
