using System;
using Catalgo.Application.Responses;
using MediatR;

namespace Catalgo.Application.Queries;

public class GetProductByNameQuery :IRequest<IList<ProductResponse>>
{
    public string Name { get; set; }
    public GetProductByNameQuery(string name) =>  Name = name;


}
