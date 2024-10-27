using MediatR;
using Omega.Core.DTOs;

namespace Omega.Domain.Queries
{
	public class GetCustomerByIdQuery : IRequest<CustomerReadDTO>
	{
		public int CustomerId { get; set; }
	}
}
