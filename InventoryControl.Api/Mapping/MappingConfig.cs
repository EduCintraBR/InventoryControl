using AutoMapper;
using InventoryControl.Api.Models;
using InventoryControl.Api.Models.Dto;

namespace InventoryControl.Api.Mapping
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
