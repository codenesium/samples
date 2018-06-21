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

                Task<List<SaleTickets>> GetTicketId(int ticketId);

                Task<Sale> GetSale(int saleId);

                Task<Ticket> GetTicket(int ticketId);
        }
}

/*<Codenesium>
    <Hash>139a76ceeedbc64343af7ed917249d41</Hash>
</Codenesium>*/