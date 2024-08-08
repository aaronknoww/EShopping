using System;
using Catalog.Core;
using AutoMapper;
using Catalgo.Application.Responses;

namespace Catalgo.Application.Mappers;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<ProductBrand, BrandResponse>().ReverseMap();         
        
    }

}
