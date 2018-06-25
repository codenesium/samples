using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
        public interface IEventRepository
        {
                Task<Event> Create(Event item);

                Task Update(Event item);

                Task Delete(int id);

                Task<Event> Get(int id);

                Task<List<Event>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Event>> ByCityId(int cityId);

                Task<City> GetCity(int cityId);
        }
}

/*<Codenesium>
    <Hash>83eb2153301aa42a0ebecf4385665f74</Hash>
</Codenesium>*/