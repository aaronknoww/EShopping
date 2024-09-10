using System;
using System.Reflection.Metadata.Ecma335;
using AutoMapper;

namespace Basket.Application.Mappers;

public static class BasketMapper
{
    private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
    {
        var config  = new MapperConfiguration( cfg => 
        {
            cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
            cfg.AddProfile<BasketMappingProfile>();
        });
        return config.CreateMapper();
    });

    public static IMapper Mapper => Lazy.Value;

    // public static IMapper Mapper
    // {
    //     get
    //     {
    //         return Lazy.Value;
    //     }
    // }


}
