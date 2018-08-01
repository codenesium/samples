using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
	public interface ITransactionRepository
	{
		Task<Transaction> Create(Transaction item);

		Task Update(Transaction item);

		Task Delete(int id);

		Task<Transaction> Get(int id);

		Task<List<Transaction>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Transaction>> ByTransactionStatusId(int transactionStatusId);

		Task<List<Sale>> Sales(int transactionId, int limit = int.MaxValue, int offset = 0);

		Task<TransactionStatus> GetTransactionStatus(int transactionStatusId);
	}
}

/*<Codenesium>
    <Hash>5aaf66ccf4be14babde39fe65bdffbff</Hash>
</Codenesium>*/