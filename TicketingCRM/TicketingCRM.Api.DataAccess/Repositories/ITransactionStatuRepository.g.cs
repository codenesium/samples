using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
	public partial interface ITransactionStatuRepository
	{
		Task<TransactionStatu> Create(TransactionStatu item);

		Task Update(TransactionStatu item);

		Task Delete(int id);

		Task<TransactionStatu> Get(int id);

		Task<List<TransactionStatu>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Transaction>> Transactions(int transactionStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>2930ba38551a0c88274806bbc41b9a05</Hash>
</Codenesium>*/