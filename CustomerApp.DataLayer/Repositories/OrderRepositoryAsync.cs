using CustomerApp.DataLayer.Contracts;
using CustomerApp.DataLayer.Dtos;
using CustomerApp.DataLayer.Models;
using CustomerApp.DataLayer.Repositories;
using NHibernate;
using NHibernate.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Customer.DataLayer.Repositories
{
    public class OrderRepositoryAsync : GenericRepositoryAsync<Order, int>, IOrderRepositoryAsync
    {
        private ISession _session;
        public OrderRepositoryAsync(ISession session) : base(session)
        {
            _session = session;
        }

        public async Task<IList<Order>> GetOrdersForCustomer(CustomerApp.DataLayer.Models.Customer customer)
        {
            return await _session.Query<Order>().Where(o => o.Customer == customer).ToListAsync();
        }

        public async Task<OrderDetailDto> GetOrderWithItems(int orderId)
        {
            var order = await GetById(orderId);

            var result = new OrderDetailDto
            {
                CustomerId = order.Customer.Id,
                CustomerName = order.Customer.Name,
                OrderDetails = order.OrderItems.ToList(),
                OrderId = order.Id,
                OrderDate = order.OrderDate,
            };
            return result;
        }
    }
}
