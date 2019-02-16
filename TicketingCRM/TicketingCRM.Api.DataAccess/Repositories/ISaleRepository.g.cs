using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
	public partial interface ISaleRepository
	{
		Task<Sale> Create(Sale item);

		Task Update(Sale item);

		Task Delete(int id);

		Task<Sale> Get(int id);

		Task<List<Sale>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Sale>> ByTransactionId(int transactionId, int limit = int.MaxValue, int offset = 0);

		Task<List<SaleTicket>> SaleTicketsBySaleId(int saleId, int limit = int.MaxValue, int offset = 0);

		Task<Transaction> TransactionByTransactionId(int transactionId);
	}
}

/*<Codenesium>
    <Hash>4ed1e14395f44f28c5cc71d0c2f70939</Hash>
</Codenesium>*/