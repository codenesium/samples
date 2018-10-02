using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
	public partial interface ITicketRepository
	{
		Task<Ticket> Create(Ticket item);

		Task Update(Ticket item);

		Task Delete(int id);

		Task<Ticket> Get(int id);

		Task<List<Ticket>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Ticket>> ByTicketStatusId(int ticketStatusId, int limit = int.MaxValue, int offset = 0);

		Task<List<SaleTicket>> SaleTickets(int ticketId, int limit = int.MaxValue, int offset = 0);

		Task<TicketStatu> GetTicketStatu(int ticketStatusId);
	}
}

/*<Codenesium>
    <Hash>afa06fd287597cd49dc8de02f73d1bb1</Hash>
</Codenesium>*/