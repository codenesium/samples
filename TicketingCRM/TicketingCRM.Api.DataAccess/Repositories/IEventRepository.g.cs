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

                Task<List<Event>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Event>> GetCityId(int cityId);

                Task<City> GetCity(int cityId);
        }
}

/*<Codenesium>
    <Hash>3d2258017c04aeb9ce94bdffebab2d33</Hash>
</Codenesium>*/