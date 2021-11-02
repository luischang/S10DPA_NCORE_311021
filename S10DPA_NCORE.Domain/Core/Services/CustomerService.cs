using AutoMapper;
using S10DPA_NCORE.Domain.Core.DTOs;
using S10DPA_NCORE.Domain.Core.Entities;
using S10DPA_NCORE.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10DPA_NCORE.Domain.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IOrderRepository orderRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<CustomerOrderDTO> GetCustomerAndOrders(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            //var orders = await _orderRepository.GetOrdersByCustomerId(id);

            var customerDTO = _mapper.Map<CustomerOrderDTO>(customer);

            //customerDTO.Order = (IEnumerable<OrderDTO>)orders;

            return customerDTO;

        }




    }
}
