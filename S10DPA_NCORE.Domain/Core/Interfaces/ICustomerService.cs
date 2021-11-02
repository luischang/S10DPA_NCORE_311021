using S10DPA_NCORE.Domain.Core.DTOs;
using System.Threading.Tasks;

namespace S10DPA_NCORE.Domain.Core.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerOrderDTO> GetCustomerAndOrders(int id);
    }
}