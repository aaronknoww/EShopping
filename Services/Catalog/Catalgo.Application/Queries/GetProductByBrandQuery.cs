using System;
using Catalgo.Application.Responses;
using MediatR;

namespace Catalgo.Application.Queries;

public class GetProductByBrandQuery : IRequest<IList<ProductResponse>>
{
    public string BrandName { get; set; }
    public GetProductByBrandQuery(string brandName) 
    {
        BrandName = brandName;
    }

}
