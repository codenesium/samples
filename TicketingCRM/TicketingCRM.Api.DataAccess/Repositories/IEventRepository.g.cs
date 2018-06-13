using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
        public interface IEventRepository
        {
                Task<Event> Create(Event item);

                Task Update(Event item);

                Task Delete(int id);

                Task<Event> Get(int id);

                Task<List<Event>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<Event>> GetCityId(int cityId);
        }
}

/*<Codenesium>
    <Hash>45eb08662fcbae9040d3bf95a2ae69e6</Hash>
</Codenesium>*/