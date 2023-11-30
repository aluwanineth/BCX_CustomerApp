using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerApp.DataLayer.Contracts
{
    public interface IGenericRepositoryAsync<TEntity, TKey>
    {
        Task<TEntity> GetById(TKey id);
        Task<IEnumerable<TEntity>> GetAll();
        Task SaveOrUpdate(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
