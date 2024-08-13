using System;
using Catalog.Core;
using AutoMapper;
using Catalgo.Application.Responses;

namespace Catalgo.Application.Mappers;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        // To map classes of core project <-----> classes of Aplication Response 
        CreateMap<ProductBrand, BrandResponse>().ReverseMap();
        CreateMap<Product, ProductResponse>().ReverseMap();         
        
    }

}
