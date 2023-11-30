using CustomerApp.DataLayer.Dtos;
using CustomerApp.DataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerApp.DataLayer.Contracts
{
    public interface ICustomerRepositoryAsync : IGenericRepositoryAsync<Models.Customer, int>
    {
        Task<CustomerDetailDto> GetCustomerWithOrders(int customerId);
    }
}
