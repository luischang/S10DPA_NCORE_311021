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
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();

            CreateMap<CustomerPostDTO, Customer>();
            CreateMap<Customer, CustomerPostDTO>();
        }




    }
}
