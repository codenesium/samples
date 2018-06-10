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

                Task<List<TicketStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>e7f98990198a9d102e3fb988a7f0ada0</Hash>
</Codenesium>*/