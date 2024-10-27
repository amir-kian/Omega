using Omega.Domain.Entities;

namespace Omega.Domain.Interfaces
{
	public interface IReadCustomerRepository
	{
		Task<Customer> GetById(int id);
		Task<List<Customer>> GetAll();
		Task<List<Customer>> GetAllCustomers();
	}
}
