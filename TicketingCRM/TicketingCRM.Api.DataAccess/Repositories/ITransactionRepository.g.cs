using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
	public partial interface ITransactionRepository
	{
		Task<Transaction> Create(Transaction item);

		Task Update(Transaction item);

		Task Delete(int id);

		Task<Transaction> Get(int id);

		Task<List<Transaction>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Transaction>> ByTransactionStatusId(int transactionStatusId, int limit = int.MaxValue, int offset = 0);

		Task<List<Sale>> Sales(int transactionId, int limit = int.MaxValue, int offset = 0);

		Task<TransactionStatus> GetTransactionStatus(int transactionStatusId);
	}
}

/*<Codenesium>
    <Hash>58a2c1be5eddd97d4e99c729453a051b</Hash>
</Codenesium>*/