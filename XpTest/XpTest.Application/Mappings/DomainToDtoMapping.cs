using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XpTest.Application.DTOs;
using XpTest.Domain.Entities;

namespace XpTest.Application.Mappings
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping()
        {
            CreateMap<Client, ClientDTO>();
            CreateMap<Client, ClientResponseDTO>();
            CreateMap<Address, AddressDTO>();
        }
    }
}
