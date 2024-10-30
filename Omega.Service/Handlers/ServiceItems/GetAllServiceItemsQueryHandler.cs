using MediatR;
using Omega.Core.DTOs;
using Omega.Domain.Interfaces;
using Omega.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omega.Service.Handlers.ServiceItems;


public class GetAllServiceItemsQueryHandler : IRequestHandler<GetAllCustomersQuery, CustomerReadDTO[]>
{
	private readonly IReadCustomerRepository _repository;

	public GetAllServiceItemsQueryHandler(IReadCustomerRepository repository)
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

