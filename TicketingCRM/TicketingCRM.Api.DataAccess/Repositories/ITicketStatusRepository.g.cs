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
    <Hash>3369489fccafc2b6419ea70c1bbd58b6</Hash>
</Codenesium>*/