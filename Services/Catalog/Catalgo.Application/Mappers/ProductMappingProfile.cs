using System;
using Catalog.Core;
using AutoMapper;
using Catalgo.Application.Responses;
using Catalgo.Application.Commands;

namespace Catalgo.Application.Mappers;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        // To map classes of core project <-----> classes of Aplication Response 
        // Response is equal to DTO
        CreateMap<ProductBrand, BrandResponse>().ReverseMap();
        CreateMap<Product, ProductResponse>().ReverseMap();
        CreateMap<ProductType, TypeResponse>().ReverseMap();
        CreateMap<Product, CreateProductCommand>().ReverseMap();         
        
    }

}
