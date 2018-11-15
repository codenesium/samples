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

		Task<List<Sale>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Sale>> ByTransactionId(int transactionId, int limit = int.MaxValue, int offset = 0);

		Task<Transaction> TransactionByTransactionId(int transactionId);

		Task<List<Sale>> BySaleId(int saleId, int limit = int.MaxValue, int offset = 0);

		Task<SaleTicket> CreateSaleTicket(SaleTicket item);

		Task DeleteSaleTicket(SaleTicket item);
	}
}

/*<Codenesium>
    <Hash>2832946b634837fa69acaecbeab90128</Hash>
</Codenesium>*/