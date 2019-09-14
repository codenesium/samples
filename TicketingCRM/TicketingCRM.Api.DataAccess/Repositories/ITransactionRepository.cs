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

		Task<List<Transaction>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Transaction>> ByTransactionStatusId(int transactionStatusId, int limit = int.MaxValue, int offset = 0);

		Task<List<Sale>> SalesByTransactionId(int transactionId, int limit = int.MaxValue, int offset = 0);

		Task<TransactionStatus> TransactionStatusByTransactionStatusId(int transactionStatusId);
	}
}

/*<Codenesium>
    <Hash>c8d085c2b9332bf5c92a46acd5bc97be</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/