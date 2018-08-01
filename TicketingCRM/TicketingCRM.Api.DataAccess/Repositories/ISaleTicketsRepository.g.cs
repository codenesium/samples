using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
	public interface ISaleTicketsRepository
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
    <Hash>b8df8d339e4a5d4f48da2f46e6d1ccfd</Hash>
</Codenesium>*/