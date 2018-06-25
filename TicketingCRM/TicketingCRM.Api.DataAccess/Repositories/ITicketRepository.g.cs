using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
        public interface ITicketRepository
        {
                Task<Ticket> Create(Ticket item);

                Task Update(Ticket item);

                Task Delete(int id);

                Task<Ticket> Get(int id);

                Task<List<Ticket>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Ticket>> ByTicketStatusId(int ticketStatusId);

                Task<List<SaleTickets>> SaleTickets(int ticketId, int limit = int.MaxValue, int offset = 0);

                Task<TicketStatus> GetTicketStatus(int ticketStatusId);
        }
}

/*<Codenesium>
    <Hash>34d27f89815b714653cb7560ca57b0d2</Hash>
</Codenesium>*/