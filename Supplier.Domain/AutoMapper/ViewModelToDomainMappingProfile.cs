using AutoMapper;
using SupplierProject.Application.DTO;
using SupplierProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupplierProject.Domain.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<SupplierDTO, Supplier>();
            CreateMap<AddressDTO, Address>();
            CreateMap<ProductDTO, Product>();
        }
    }
}
