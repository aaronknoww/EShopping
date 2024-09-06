using System;
using Catalgo.Application.Responses;
using Catalog.Core.Specs;
using MediatR;

namespace Catalgo.Application.Queries;

public class GetAllProductsQuery : IRequest<Pagination<ProductResponse>>
{
    public CatalogSpecParams CatalogSpecParams { get; set; }

    public GetAllProductsQuery(CatalogSpecParams catalogSpecParams)
    {
        this.CatalogSpecParams = catalogSpecParams;
    }

}
