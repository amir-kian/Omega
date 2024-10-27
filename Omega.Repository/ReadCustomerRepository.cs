using Microsoft.EntityFrameworkCore;
using Omega.Domain.Entities;
using Omega.Domain.Interfaces;
using Omega.Presentation.Infrastructure;

namespace Omega.Repository
{
	public class ReadCustomerRepository : IReadCustomerRepository
	{
		private readonly AppDbContext _dbContext;

		public ReadCustomerRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<List<Customer>> GetAll()
		{
			return await _dbContext.Set<Customer>().ToListAsync();
		}

		public async Task<Customer> GetById(int id)
		{
			return await _dbContext.Set<Customer>().SingleOrDefaultAsync(c => c.Id == id);
		}

		public async Task<List<Customer>> GetAllCustomers()
		{
			return await _dbContext.Set<Customer>().ToListAsync();
		}
	}
}
