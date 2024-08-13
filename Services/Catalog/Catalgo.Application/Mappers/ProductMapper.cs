using AutoMapper;

namespace Catalgo.Application.Mappers;

public static class ProductMapper
{
    private static readonly Lazy<IMapper> _mapper = new Lazy<IMapper>(() =>
    {
        MapperConfiguration config = new MapperConfiguration(cfg => 
        {
            cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
            cfg.AddProfile<ProductMappingProfile>();
        });
        IMapper mapper = config.CreateMapper();
        return mapper;
    });
    public static IMapper Mapper => _mapper.Value;

}
