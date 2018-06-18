using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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
    <Hash>7b768d2ac934fe6ff66c3c2197579df8</Hash>
</Codenesium>*/