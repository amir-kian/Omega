using MediatR;
using Omega.Domain.Queries;
using Omega.Domain.Interfaces;
using Omega.Core.DTOs;


namespace Omega.Service.Handlers
{
	public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, CustomerReadDTO[]>
	{
		private readonly IReadCustomerRepository _repository;

		public GetAllCustomersQueryHandler(IReadCustomerRepository repository)
		{
			_repository = repository;
		}

		public async Task<CustomerReadDTO[]> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
		{
			var customers = await _repository.GetAllCustomers();
			var result = new CustomerReadDTO[customers.Count];

			for (var i = 0; i < customers.Count; i++)
			{
				result[i] = new CustomerReadDTO
				{
					Id = customers[i].Id,
					Firstname = customers[i].Firstname,
					Lastname = customers[i].Lastname,
					DateOfBirth = customers[i].DateOfBirth,
					PhoneNumber = customers[i].PhoneNumber.ToString(), // Convert PhoneNumber to string
					Email = customers[i].Email.ToString() // Convert Email to string
				};
			}

			return result;
		}
	}
}
