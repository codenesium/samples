using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
        public interface ISaleTicketsRepository
        {
                Task<SaleTickets> Create(SaleTickets item);

                Task Update(SaleTickets item);

                Task Delete(int id);

                Task<SaleTickets> Get(int id);

                Task<List<SaleTickets>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<SaleTickets>> GetTicketId(int ticketId);
        }
}

/*<Codenesium>
    <Hash>4ce616c75c2995bf71f81296dd7c7107</Hash>
</Codenesium>*/