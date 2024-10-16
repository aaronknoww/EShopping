using System;
using System.Linq.Expressions;
using Ordering.Core.Common;
using Ordering.Core.Repositories;

namespace Ordering.Infrastructure.Repositories;

public class RepositoryBase : IAsyncRepository<EntityBase>
{
    public Task DeleteAsync(EntityBase entity)
    {
        throw new NotImplementedException();
    }

    public Task<EntityBase> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<EntityBase>> GetAllAsync(Expression<Predicate<EntityBase>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<EntityBase> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(EntityBase entity)
    {
        throw new NotImplementedException();
    }
}
