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

                Task<List<Event>> GetCityId(int cityId);

                Task<City> GetCity(int cityId);
        }
}

/*<Codenesium>
    <Hash>7ea7c40c02a2066401e4fdab27466c2f</Hash>
</Codenesium>*/