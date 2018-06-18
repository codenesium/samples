using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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

                Task<List<Ticket>> GetTicketStatusId(int ticketStatusId);

                Task<List<SaleTickets>> SaleTickets(int ticketId, int limit = int.MaxValue, int offset = 0);

                Task<TicketStatus> GetTicketStatus(int ticketStatusId);
        }
}

/*<Codenesium>
    <Hash>085afb38bc8f156d2cb9ea8eaab70bb2</Hash>
</Codenesium>*/