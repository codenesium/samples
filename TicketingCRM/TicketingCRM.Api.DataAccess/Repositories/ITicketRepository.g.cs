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

		Task<List<Ticket>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Ticket>> ByTicketStatusId(int ticketStatusId, int limit = int.MaxValue, int offset = 0);

		Task<List<SaleTickets>> SaleTicketsByTicketId(int ticketId, int limit = int.MaxValue, int offset = 0);

		Task<TicketStatus> TicketStatusByTicketStatusId(int ticketStatusId);
	}
}

/*<Codenesium>
    <Hash>c3416851d57794f87e2566a6e159ccb4</Hash>
</Codenesium>*/