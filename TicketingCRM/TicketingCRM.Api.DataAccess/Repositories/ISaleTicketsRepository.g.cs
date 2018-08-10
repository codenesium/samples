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

		Task<List<SaleTickets>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<SaleTickets>> ByTicketId(int ticketId);

		Task<Sale> GetSale(int saleId);

		Task<Ticket> GetTicket(int ticketId);
	}
}

/*<Codenesium>
    <Hash>b4517fb63ebee75609b69f80347d6a63</Hash>
</Codenesium>*/