using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
	public partial interface ITransactionStatusRepository
	{
		Task<TransactionStatus> Create(TransactionStatus item);

		Task Update(TransactionStatus item);

		Task Delete(int id);

		Task<TransactionStatus> Get(int id);

		Task<List<TransactionStatus>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Transaction>> Transactions(int transactionStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d3a968a313ff524056ef4a219a2381b8</Hash>
</Codenesium>*/