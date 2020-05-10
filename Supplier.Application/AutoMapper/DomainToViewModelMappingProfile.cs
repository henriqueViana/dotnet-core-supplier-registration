using AutoMapper;
using SupplierProject.Application.DTO;
using SupplierProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupplierProject.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Supplier, SupplierDTO>();
            CreateMap<Address, AddressDTO>();
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.Name));
        }
    }
}
