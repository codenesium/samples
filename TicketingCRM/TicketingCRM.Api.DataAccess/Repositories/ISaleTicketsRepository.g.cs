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

		Task<List<SaleTickets>> ByTicketId(int ticketId, int limit = int.MaxValue, int offset = 0);

		Task<Sale> GetSale(int saleId);

		Task<Ticket> GetTicket(int ticketId);
	}
}

/*<Codenesium>
    <Hash>69eab666dd4a35a72fbbff5e7a0fb5eb</Hash>
</Codenesium>*/