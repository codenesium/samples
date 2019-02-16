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

		Task<List<TransactionStatu>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Transaction>> TransactionsByTransactionStatusId(int transactionStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>da38a6cf0469b26ec7f8b09f1e90344e</Hash>
</Codenesium>*/