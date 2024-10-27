using Microsoft.EntityFrameworkCore;
using Omega.Domain.Interfaces.Request;
using Omega.Presentation.Infrastructure;

namespace Omega.Repository.Request
{
	public class WriteRequestRepository : IWriteRequestRepository
	{
		private readonly AppDbContext _dbContext;

		public WriteRequestRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<int> Add(Domain.Entities.Request customer)
		{
			await _dbContext.Requests.AddAsync(customer);
			await _dbContext.SaveChangesAsync();
			return customer.Id;
		}

		public async Task Delete(Domain.Entities.Request customer)
		{
			_dbContext.Requests.Remove(customer);
			await _dbContext.SaveChangesAsync();
		}

		public async Task Update(Domain.Entities.Request customer)
		{
			_dbContext.Entry(customer).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
		}

		public async Task<Domain.Entities.Request> GetById(int id)
		{
			return await _dbContext.Requests.FindAsync(id);
		}
	}
}
