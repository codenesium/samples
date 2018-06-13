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

                Task<List<Ticket>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<Ticket>> GetTicketStatusId(int ticketStatusId);

                Task<List<SaleTickets>> SaleTickets(int ticketId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>0ae564d128208493b62ee54f1c16270f</Hash>
</Codenesium>*/