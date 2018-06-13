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

                Task<List<TicketStatus>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<Ticket>> Tickets(int ticketStatusId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>36b15acc9e6196d5c7fda1a770af02d4</Hash>
</Codenesium>*/