
using Microsoft.EntityFrameworkCore;
using Omega.Domain.Interfaces.Request;
using Omega.Presentation.Infrastructure;

namespace Omega.Repository.Request
{
	public class RequestRepository : IRequestRepository
	{
		private readonly AppDbContext _dbContext;

		public RequestRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void Add(Domain.Entities.Request Request)
		{
			_dbContext.Set<Domain.Entities.Request>().Add(Request);
			_dbContext.SaveChanges();
		}

		public IEnumerable<Domain.Entities.Request> GetAllRequests()
		{
			return _dbContext.Set<Domain.Entities.Request>().ToList();
		}

		public Domain.Entities.Request GetById(int RequestId)
		{
			return _dbContext.Set<Domain.Entities.Request>().SingleOrDefault(c => c.Id == RequestId);
		}

		public void Update(Domain.Entities.Request Request)
		{
			_dbContext.Entry(Request).State = EntityState.Modified;
			_dbContext.SaveChanges();
		}

		public void Delete(Domain.Entities.Request Request)
		{
			_dbContext.Set<Domain.Entities.Request>().Remove(Request);
			_dbContext.SaveChanges();
		}
	}
}