using MediatR;
using Omega.Core.DTOs;

namespace Omega.Domain.Queries
{
	public class GetAllCustomersQuery : IRequest<CustomerReadDTO[]>
	{
	}
}
