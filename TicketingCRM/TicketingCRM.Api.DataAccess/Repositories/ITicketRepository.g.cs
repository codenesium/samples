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

                Task<List<Ticket>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<Ticket>> GetTicketStatusId(int ticketStatusId);
        }
}

/*<Codenesium>
    <Hash>148eaa1bc9e97ad8f0ac59bac7f4f002</Hash>
</Codenesium>*/