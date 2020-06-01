using AutoMapper;
using SupplierProject.Domain.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupplierProject.Tests.Config
{
    public class AutoMapperSingleton
    {
        private static IMapper _mapper;

        public static IMapper Mapper { get 
            {
                if (_mapper == null)
                {
                    _mapper = GetInstanceConfig();
                }

                return _mapper;
            } 
        }

        private static IMapper GetInstanceConfig()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DomainToViewModelMappingProfile());
                mc.AddProfile(new ViewModelToDomainMappingProfile());
            });

            return mappingConfig.CreateMapper();
        }
    }
}
