using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using S10DPA_NCORE.Domain.Core.DTOs;
using S10DPA_NCORE.Domain.Core.Entities;
using S10DPA_NCORE.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S10DPA_NCORE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerRepository customerRepository, IMapper mapper,
            ICustomerService customerService)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _customerService = customerService;
        }

        [HttpGet]
        [Route("GetCustomers")]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _customerRepository.GetCustomers();
            //var customersList = new List<CustomerDTO>();

            //foreach (var item in customers)
            //{
            //    var customerDTO = new CustomerDTO()
            //    {
            //        Id = item.Id,
            //        FirstName = item.FirstName,
            //        LastName = item.LastName,
            //        Country = item.Country,
            //        City = item.City,
            //        Phone = item.Phone
            //    };
            //    customersList.Add(customerDTO);
            //}
            var customersList = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
            return Ok(customersList);
        }

        [HttpGet]
        [Route("GetCustomerById/{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            if (customer == null)
                return NotFound();
            //var customerDTO = new CustomerDTO()
            //{
            //    Id = customer.Id,
            //    FirstName = customer.FirstName,
            //    LastName = customer.LastName,
            //    Country = customer.Country,
            //    City = customer.City,
            //    Phone = customer.Phone
            //};
            var customerDTO = _mapper.Map<CustomerDTO>(customer);
            return Ok(customerDTO);
        }

        [HttpPost]
        [Route("PostCustomer")]
        public async Task<IActionResult> PostCustomer(CustomerPostDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            var result = await _customerRepository.Insert(customer);
            return Ok(result ? customer.Id : -1);
        }

        [HttpPut]
        [Route("PutCustomer")]
        public async Task<IActionResult> PutCustomer(CustomerDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            var result = await _customerRepository.Update(customer);
            return Ok(result ? customer.Id : -1);
        }

        [HttpDelete]
        [Route("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await _customerRepository.Delete(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpGet]
        [Route("GetCustomerAndOrders/{id}")]
        public async Task<IActionResult> GetCustomerAndOrders(int id)
        {
            var customerDTO = await _customerService.GetCustomerAndOrders(id);
            if (customerDTO == null)
                return NotFound();    
            
            return Ok(customerDTO);
        }
    }
}
