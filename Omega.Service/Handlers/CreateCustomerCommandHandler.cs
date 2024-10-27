﻿using MediatR;
using Omega.Domain.Commands;
using Omega.Domain.Entities;
using Omega.Domain.Events;
using Omega.Domain.Interfaces;
using Omega.Domain.ValueObjects;
using PhoneNumbers;

namespace Omega.Service.Handlers
{
	public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
	{
		private readonly IWriteCustomerRepository _repository;
		private readonly ICustomerEventHandler _customerEventHandler;

		public CreateCustomerCommandHandler(IWriteCustomerRepository repository, ICustomerEventHandler customerEventHandler)
		{
			_repository = repository;
			_customerEventHandler = customerEventHandler;
		}

		public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
		{
			var phoneNumber = new Domain.ValueObjects.PhoneNumber(request.PhoneNumber);
			var email = new Email(request.Email);
			var bankAccountNumber = new BankAccountNumber(request.BankAccountNumber);

			var customer = new Customer(request.Firstname, request.Lastname, request.DateOfBirth, phoneNumber, email, bankAccountNumber);

			await _repository.Add(customer);

			var createdEvent = new CustomerCreatedEvent(
				customer.Id,
				customer.Firstname,
				customer.Lastname,
				customer.DateOfBirth,
				customer.PhoneNumber,
				customer.Email,
				customer.BankAccountNumber
			);
			await _customerEventHandler.Handle(createdEvent);

			return customer;
		}
	}
}