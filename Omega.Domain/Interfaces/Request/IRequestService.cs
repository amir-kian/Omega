using Omega.Domain.Entities;
using Omega.Domain.ValueObjects;

namespace Omega.Domain.Interfaces.Request
{
	public interface IRequestService
	{
		Entities.Request CreateRequest(string firstName, string lastName, DateTime dateOfBirth, PhoneNumber phoneNumber, Email Email, BankAccountNumber bankAccountNumber);
		Entities.Request GetRequestById(int RequestId);
		IEnumerable<Entities.Request> GetAllRequests();
		void UpdateRequest(int RequestId, string firstName, string lastName, DateTime dateOfBirth, PhoneNumber phoneNumber, Email email, BankAccountNumber bankAccountNumber);
		void DeleteRequest(int RequestId);
	}
}
