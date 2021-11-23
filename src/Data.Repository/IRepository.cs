namespace PlutoRover.Data.Repository
{
    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task AddAsync(TEntity obj);

        Task<TEntity> GetAsync(Guid id);

        Task UpdateAsync(Guid id, TEntity obj);

        Task RemoveAsync(Guid id);

        Task DeleteOneAsync(Expression<Func<TEntity, bool>> query);
    }
}
