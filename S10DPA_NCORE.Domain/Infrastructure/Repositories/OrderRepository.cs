using Microsoft.EntityFrameworkCore;
using S10DPA_NCORE.Domain.Core.Entities;
using S10DPA_NCORE.Domain.Core.Interfaces;
using S10DPA_NCORE.Domain.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10DPA_NCORE.Domain.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private readonly SalesDBContext _context;

        public OrderRepository(SalesDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _context.Order.ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerId(int id)
        {
            return await _context.Order
                .Include(nameof(OrderItem))
                .Where(x => x.CustomerId == id).ToListAsync();
        }


    }
}
