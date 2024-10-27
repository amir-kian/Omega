
using Microsoft.EntityFrameworkCore;
using Omega.Domain.Interfaces.Request;
using Omega.Presentation.Infrastructure;

namespace Omega.Repository.Request
{
	public class ReadRequestRepository : IReadRequestRepository
	{
		private readonly AppDbContext _dbContext;

		public ReadRequestRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<List<Domain.Entities.Request>> GetAll()
		{
			return await _dbContext.Set<Domain.Entities.Request>().ToListAsync();
		}

		public async Task<Domain.Entities.Request> GetById(int id)
		{
			return await _dbContext.Set<Domain.Entities.Request>().SingleOrDefaultAsync(c => c.Id == id);
		}

		public async Task<List<Domain.Entities.Request>> GetAllRequests()
		{
			return await _dbContext.Set<Domain.Entities.Request>().ToListAsync();
		}
	}
}
