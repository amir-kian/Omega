using Omega.Domain.Entities;

namespace Omega.Domain.Interfaces.Request
{
	public interface IWriteRequestRepository
	{
		Task<int> Add(Entities.Request entity);
		Task Update(Entities.Request entity);
		Task Delete(Entities.Request entity);
		Task<Entities.Request> GetById(int id);
	}
}

