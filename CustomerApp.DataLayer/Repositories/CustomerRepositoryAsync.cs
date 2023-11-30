using CustomerApp.DataLayer.Contracts;
using CustomerApp.DataLayer.Dtos;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApp.DataLayer.Repositories
{
    public sealed class CustomerRepositoryAsync : GenericRepositoryAsync<Models.Customer, int>, ICustomerRepositoryAsync
    {
        private readonly ISession _session;
        public CustomerRepositoryAsync(ISession session) : base(session)
        {
            _session = session;
        }
        public async Task<CustomerDetailDto> GetCustomerWithOrders(int customerId)
        {
            var customer = await GetById(customerId);
            var result = new CustomerDetailDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Orders = customer.Orders.ToList(),
            };
            return result;
        }
    }
}
