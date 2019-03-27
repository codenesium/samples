using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
	public partial interface ISaleTicketsRepository
	{
		Task<SaleTickets> Create(SaleTickets item);

		Task Update(SaleTickets item);

		Task Delete(int id);

		Task<SaleTickets> Get(int id);

		Task<List<SaleTickets>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<SaleTickets>> ByTicketId(int ticketId, int limit = int.MaxValue, int offset = 0);

		Task<Sale> SaleBySaleId(int saleId);

		Task<Ticket> TicketByTicketId(int ticketId);
	}
}

/*<Codenesium>
    <Hash>7abaee10d1e5885f167fa0d8f279d98e</Hash>
</Codenesium>*/