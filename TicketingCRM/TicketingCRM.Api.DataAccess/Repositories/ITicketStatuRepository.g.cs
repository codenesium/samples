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

		Task<List<TicketStatu>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Ticket>> TicketsByTicketStatusId(int ticketStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>b3e9757640849bb4c030880fda3e46ab</Hash>
</Codenesium>*/