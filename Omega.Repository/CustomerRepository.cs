
using Microsoft.EntityFrameworkCore;
using Omega.Domain.Entities;
using Omega.Domain.Interfaces;
using Omega.Presentation.Infrastructure;

namespace Omega.Repository
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly AppDbContext _dbContext;

		public CustomerRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void Add(Customer customer)
		{
			_dbContext.Set<Customer>().Add(customer);
			_dbContext.SaveChanges();
		}

		public IEnumerable<Customer> GetAllCustomers()
		{
			return _dbContext.Set<Customer>().ToList();
		}

		public Customer GetById(int customerId)
		{
			return _dbContext.Set<Customer>().SingleOrDefault(c => c.Id == customerId);
		}

		public void Update(Customer customer)
		{
			_dbContext.Entry(customer).State = EntityState.Modified;
			_dbContext.SaveChanges();
		}

		public void Delete(Customer customer)
		{
			_dbContext.Set<Customer>().Remove(customer);
			_dbContext.SaveChanges();
		}
	}
}