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

		Task<List<Sale>> SalesByTransactionId(int transactionId, int limit = int.MaxValue, int offset = 0);

		Task<TransactionStatu> TransactionStatuByTransactionStatusId(int transactionStatusId);
	}
}

/*<Codenesium>
    <Hash>05e8d3438b5dff6e6f2d310bfcfa6da2</Hash>
</Codenesium>*/