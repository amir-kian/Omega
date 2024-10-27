using Omega.Domain.Entities;
using Omega.Domain.ValueObjects;

namespace Omega.Domain.Interfaces
{
	public interface ICustomerService
	{
		Customer CreateCustomer(string firstName, string lastName, DateTime dateOfBirth, PhoneNumber phoneNumber, Email Email, BankAccountNumber bankAccountNumber);
		Customer GetCustomerById(int customerId);
		IEnumerable<Customer> GetAllCustomers();
		void UpdateCustomer(int customerId, string firstName, string lastName, DateTime dateOfBirth, PhoneNumber phoneNumber, Email email, BankAccountNumber bankAccountNumber);
		void DeleteCustomer(int customerId);
	}
}
