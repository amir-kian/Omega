using Omega.Domain.Entities;

namespace Omega.Domain.Interfaces
{
	public interface IWriteCustomerRepository
	{
		Task<int> Add(Customer entity);
		Task Update(Customer entity);
		Task Delete(Customer entity);
		Task<Customer> GetById(int id);
	}
}

