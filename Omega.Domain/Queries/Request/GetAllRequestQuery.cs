using MediatR;
using Omega.Core.DTOs.Request;

namespace Omega.Domain.Queries.Request;

public class GetAllRequestsQuery : IRequest<RequestReadDTO[]>
{
}
