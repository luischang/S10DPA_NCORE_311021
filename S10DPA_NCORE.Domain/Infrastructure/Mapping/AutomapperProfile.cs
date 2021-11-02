using AutoMapper;
using S10DPA_NCORE.Domain.Core.DTOs;
using S10DPA_NCORE.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10DPA_NCORE.Domain.Infrastructure.Mapping
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();

            CreateMap<CustomerPostDTO, Customer>();
            CreateMap<Customer, CustomerPostDTO>();

            CreateMap<Customer, CustomerOrderDTO>();
            CreateMap<CustomerOrderDTO, Customer>();

            CreateMap<Customer, IEnumerable<CustomerOrderDTO>>();
            CreateMap<IEnumerable<CustomerOrderDTO>, Customer>();

            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();

            CreateMap<Order, OrderDetailsDTO>();
            CreateMap<OrderDetailsDTO, Order>();

        }




    }
}
