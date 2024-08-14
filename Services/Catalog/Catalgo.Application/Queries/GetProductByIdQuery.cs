using System;
using Catalgo.Application.Responses;
using MediatR;

namespace Catalgo.Application.Queries;

public class GetProductByIdQuery : IRequest<ProductResponse>
{
    public string Id { get; set; }
    public GetProductByIdQuery(string id) => Id = id;


}
