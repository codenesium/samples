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

                Task<List<Event>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<Event>> GetCityId(int cityId);
        }
}

/*<Codenesium>
    <Hash>fcedd5ab5a825bb2554b10f71553b9f5</Hash>
</Codenesium>*/