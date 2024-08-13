using System;
using Catalgo.Application.Mappers;
using Catalgo.Application.Queries;
using Catalgo.Application.Responses;
using Catalog.Core;
using MediatR;

namespace Catalgo.Application.Handlers;

public class GetAllTypesHandler : IRequestHandler<GetAllTypesQuery, IList<TypeResponse>>
{
    private readonly ITypesRepository _typesRepository;

    public GetAllTypesHandler(ITypesRepository typesRepository)
    {
        this._typesRepository = typesRepository;
    }
    public async Task<IList<TypeResponse>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<ProductType> typeList = await _typesRepository.GetAllTypes();
        IList<TypeResponse> TypeResponseList = ProductMapper.Mapper.Map<IList<TypeResponse>>(typeList);
        return TypeResponseList;
    }
}
