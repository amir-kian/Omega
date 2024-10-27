using MediatR;
using Omega.Core.DTOs;
using Omega.Domain.Interfaces;
using Omega.Domain.Queries;


namespace Omega.Service.Handlers
{
	public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerReadDTO>
	{
		private readonly IReadCustomerRepository _repository;

		public GetCustomerByIdQueryHandler(IReadCustomerRepository repository)
		{
			_repository = repository;
		}

		public async Task<CustomerReadDTO> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
		{
			var customer = await _repository.GetById(request.CustomerId);

			if (customer == null)
			{
				return null;
			}

			return new CustomerReadDTO
			{
				Id = customer.Id,
				Firstname = customer.Firstname,
				Lastname = customer.Lastname,
				DateOfBirth = customer.DateOfBirth,
				PhoneNumber = customer.PhoneNumber.ToString(),
				Email = customer.Email.ToString() 
			};
		}
	}
}
