using CustomerApp.DataLayer.Dtos;
using CustomerApp.DataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerApp.DataLayer.Contracts
{
    public interface IOrderRepositoryAsync : IGenericRepositoryAsync<Order, int>
    {
        Task<IList<Order>> GetOrdersForCustomer(Models.Customer customer);
        Task<OrderDetailDto> GetOrderWithItems(int orderId);
    }
}

