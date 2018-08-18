using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
	public partial interface ITicketStatusRepository
	{
		Task<TicketStatus> Create(TicketStatus item);

		Task Update(TicketStatus item);

		Task Delete(int id);

		Task<TicketStatus> Get(int id);

		Task<List<TicketStatus>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Ticket>> Tickets(int ticketStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>eb4b724355fc05d6561e30398de5dfea</Hash>
</Codenesium>*/