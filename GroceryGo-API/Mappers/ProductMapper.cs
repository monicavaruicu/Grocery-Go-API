using AutoMapper;
using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<ProductDTO, Product>();
        CreateMap<Product, ProductDTO>();
    }
}
