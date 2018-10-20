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

		Task<List<Transaction>> TransactionsByTransactionStatusId(int transactionStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>7c025b0dc8c0e11627d2e0706f65f5dd</Hash>
</Codenesium>*/