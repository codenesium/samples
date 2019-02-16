using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
	public partial interface ISaleTicketRepository
	{
		Task<SaleTicket> Create(SaleTicket item);

		Task Update(SaleTicket item);

		Task Delete(int id);

		Task<SaleTicket> Get(int id);

		Task<List<SaleTicket>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<SaleTicket>> ByTicketId(int ticketId, int limit = int.MaxValue, int offset = 0);

		Task<Sale> SaleBySaleId(int saleId);

		Task<Ticket> TicketByTicketId(int ticketId);
	}
}

/*<Codenesium>
    <Hash>f3dc71dc5e8219ce5d498207080c6a86</Hash>
</Codenesium>*/