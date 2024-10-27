using MediatR;
using Omega.Core.DTOs.Request;

namespace Omega.Domain.Queries.Request;

public class GetRequestByIdQuery : IRequest<RequestReadDTO>
{
	public int RequestId { get; set; }
}
