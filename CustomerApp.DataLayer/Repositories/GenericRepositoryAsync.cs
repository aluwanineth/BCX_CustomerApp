using CustomerApp.DataLayer.Contracts;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerApp.DataLayer.Repositories
{
    public class GenericRepositoryAsync<TEntity, TKey> : IGenericRepositoryAsync<TEntity, TKey>
    {
        protected ISession Session { get; }

        public GenericRepositoryAsync(ISession session)
        {
            Session = session ?? throw new ArgumentNullException(nameof(session));
        }
        public async Task DeleteAsync(TEntity entity)
        {
            using (var transaction = Session.BeginTransaction())
            {
                await Session.DeleteAsync(entity);
                transaction.Commit();
            }
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Session.Query<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(TKey id)
        {
            return await Session.GetAsync<TEntity>(id);
        }

        public async Task SaveOrUpdate(TEntity entity)
        {
            using (var transaction = Session.BeginTransaction())
            {
                await Session.SaveOrUpdateAsync(entity);
                transaction.Commit();
            }
        }
    }
}
