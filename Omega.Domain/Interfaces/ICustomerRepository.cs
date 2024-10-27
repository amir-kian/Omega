using Omega.Domain.Entities;

namespace Omega.Domain.Interfaces
{
	public interface ICustomerRepository
	{
		void Add(Customer customer);
		Customer GetById(int customerId);
		void Update(Customer customer);
		void Delete(Customer customer);
		IEnumerable<Customer> GetAllCustomers();

	}
}
