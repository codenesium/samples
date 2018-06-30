using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
        public interface ISaleTicketsRepository
        {
                Task<SaleTickets> Create(SaleTickets item);

                Task Update(SaleTickets item);

                Task Delete(int id);

                Task<SaleTickets> Get(int id);

                Task<List<SaleTickets>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<SaleTickets>> ByTicketId(int ticketId);

                Task<Sale> GetSale(int saleId);

                Task<Ticket> GetTicket(int ticketId);
        }
}

/*<Codenesium>
    <Hash>7477a651ee7f29ca2911294b6d070150</Hash>
</Codenesium>*/