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

		Task<List<SaleTicket>> SaleTicketsByTicketId(int ticketId, int limit = int.MaxValue, int offset = 0);

		Task<TicketStatus> TicketStatusByTicketStatusId(int ticketStatusId);
	}
}

/*<Codenesium>
    <Hash>78a4451717c8e2cb2d3e1ac0014945d7</Hash>
</Codenesium>*/