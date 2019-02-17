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

		Task<List<TicketStatus>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Ticket>> TicketsByTicketStatusId(int ticketStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>0fd74e1511e36fb761c2934690ef2411</Hash>
</Codenesium>*/