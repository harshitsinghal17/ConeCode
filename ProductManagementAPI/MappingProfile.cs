using AutoMapper;
using ProductManagementAPI.Product;

namespace ProductManagementAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product.Product, ProductEntity>();
            CreateMap<ProductEntity, Product.Product>();
        }
    }
}
