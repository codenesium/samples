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

                Task<List<SaleTickets>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<SaleTickets>> GetTicketId(int ticketId);
        }
}

/*<Codenesium>
    <Hash>ebc6a631adeb6fc300e4da9ed588ac2d</Hash>
</Codenesium>*/