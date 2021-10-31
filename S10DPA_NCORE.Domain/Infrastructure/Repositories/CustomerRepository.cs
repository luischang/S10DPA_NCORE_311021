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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SalesDBContext _context;

        public CustomerRepository(SalesDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _context.Customer.ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _context.Customer.FindAsync(id);
        }

        public async Task<bool> Insert(Customer customer)
        {
            _context.Customer.Add(customer);
            int countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }
        public async Task<bool> Update(Customer customer)
        {
            var customerNow = await _context.Customer.FindAsync(customer.Id);
            customerNow.FirstName = customer.FirstName;
            customerNow.LastName = customer.LastName;
            customerNow.Country = customer.Country;
            customerNow.City = customer.City;
            customerNow.Phone = customer.Phone;

            int countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Delete(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customer);
            int countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }




    }
}
