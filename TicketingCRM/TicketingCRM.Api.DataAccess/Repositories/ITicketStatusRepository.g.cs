using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
	public interface ITicketStatusRepository
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
    <Hash>f346b70e5d02d1159c61f386ce0db8db</Hash>
</Codenesium>*/