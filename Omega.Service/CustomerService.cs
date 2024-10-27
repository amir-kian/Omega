
using Omega.Domain.Entities;
using Omega.Domain.Events;
using Omega.Domain.Interfaces;
using Omega.Domain.ValueObjects;

namespace Omega.Service
{
	public class CustomerService : ICustomerService
	{
		private readonly ICustomerRepository _customerRepository;
		private readonly IEventDispatcher _eventDispatcher;

		public CustomerService(ICustomerRepository customerRepository, IEventDispatcher eventDispatcher)
		{
			_customerRepository = customerRepository;
			_eventDispatcher = eventDispatcher;
		}


		public Customer CreateCustomer(string firstName, string lastName, DateTime dateOfBirth, PhoneNumber phoneNumber, Email email, BankAccountNumber bankAccountNumber)
		{
			var customer = new Customer(firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber);

			_customerRepository.Add(customer);

			var customerCreatedEvent = new CustomerCreatedEvent(
				customer.Id,
				customer.Firstname,
				customer.Lastname,
				customer.DateOfBirth,
				customer.PhoneNumber,
				customer.Email,
				customer.BankAccountNumber
			);
			_eventDispatcher.Dispatch(customerCreatedEvent);

			return customer;
		}

		public IEnumerable<Customer> GetAllCustomers()
		{
			return _customerRepository.GetAllCustomers();
		}

		public Customer GetCustomerById(int customerId)
		{
			return _customerRepository.GetById(customerId);
		}

		public void UpdateCustomer(int customerId, string firstName, string lastName, DateTime dateOfBirth, PhoneNumber phoneNumber, Email email, BankAccountNumber bankAccountNumber)
		{
			var customer = _customerRepository.GetById(customerId);
			if (customer == null)
			{
				throw new ArgumentException($"Customer with ID {customerId} does not exist.");
			}

			customer.Update(firstName, lastName, dateOfBirth);

			_customerRepository.Update(customer);

			var customerUpdatedEvent = new CustomerUpdatedEvent(
				customer.Id,
				customer.Firstname,
				customer.Lastname,
				customer.DateOfBirth,
				customer.PhoneNumber,
				customer.Email,
				customer.BankAccountNumber
			);

			_eventDispatcher.Dispatch(customerUpdatedEvent);
		}
		public void DeleteCustomer(int customerId)
		{
			var customer = _customerRepository.GetById(customerId);
			if (customer == null)
			{
				throw new ArgumentException($"Customer with ID {customerId} does not exist.");
			}
			_customerRepository.Delete(customer);

			// Create and dispatch the CustomerDeletedEvent
			var customerDeletedEvent = new CustomerDeletedEvent(customer.Id);
			_eventDispatcher.Dispatch(customerDeletedEvent);
		}




	}
}
