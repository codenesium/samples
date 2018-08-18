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
    <Hash>d439167eb74c08d1d6cf4e6c7e1a836c</Hash>
</Codenesium>*/