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
                    var mappingConfig = new MapperConfiguration(mc =>
                    {
                        mc.AddProfile(new DomainToViewModelMappingProfile());
                        mc.AddProfile(new ViewModelToDomainMappingProfile());
                    });

                    IMapper mapper = mappingConfig.CreateMapper();
                    _mapper = mapper;
                }

                return _mapper;
            } 
        }
    }
}
