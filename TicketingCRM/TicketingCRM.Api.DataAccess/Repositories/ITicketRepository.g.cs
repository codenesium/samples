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

		Task<List<SaleTickets>> SaleTickets(int ticketId, int limit = int.MaxValue, int offset = 0);

		Task<TicketStatus> GetTicketStatus(int ticketStatusId);
	}
}

/*<Codenesium>
    <Hash>4658f13f923494ce035397d40a0e0429</Hash>
</Codenesium>*/