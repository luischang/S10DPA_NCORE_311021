using S10DPA_NCORE.Domain.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S10DPA_NCORE.Domain.Core.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<IEnumerable<Order>> GetOrdersByCustomerId(int id);
    }
}