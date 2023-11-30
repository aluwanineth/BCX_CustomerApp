using CustomerApp.DataLayer.Contracts;
using CustomerApp.DataLayer.Models;
using CustomerApp.DataLayer.Repositories;
using NHibernate;

namespace Customer.DataLayer.Repositories
{
    public class OrderDetailRepositoryAsync : GenericRepositoryAsync<OrderDetail, int>, IOrderIDetailRepositoryAsync
    {
        public OrderDetailRepositoryAsync(ISession session) : base(session)
        {
        }
    }
}
