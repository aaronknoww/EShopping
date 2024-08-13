using System;
using Catalgo.Application.Responses;
using MediatR;

namespace Catalgo.Application.Queries;

public class GetAllTypesQuery : IRequest<IList<TypeResponse>>
{

}
