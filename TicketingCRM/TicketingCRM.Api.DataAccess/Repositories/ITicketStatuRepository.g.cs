using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
	public partial interface ITicketStatuRepository
	{
		Task<TicketStatu> Create(TicketStatu item);

		Task Update(TicketStatu item);

		Task Delete(int id);

		Task<TicketStatu> Get(int id);

		Task<List<TicketStatu>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Ticket>> Tickets(int ticketStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>2e98f7d52b7cef85e0eeb5c97944c540</Hash>
</Codenesium>*/