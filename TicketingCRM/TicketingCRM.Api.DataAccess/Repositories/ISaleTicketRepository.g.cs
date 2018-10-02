using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
	public partial interface ISaleTicketRepository
	{
		Task<SaleTicket> Create(SaleTicket item);

		Task Update(SaleTicket item);

		Task Delete(int id);

		Task<SaleTicket> Get(int id);

		Task<List<SaleTicket>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<SaleTicket>> ByTicketId(int ticketId, int limit = int.MaxValue, int offset = 0);

		Task<Sale> GetSale(int saleId);

		Task<Ticket> GetTicket(int ticketId);
	}
}

/*<Codenesium>
    <Hash>6c520d671c7452aa84ae43f8f9b9381f</Hash>
</Codenesium>*/