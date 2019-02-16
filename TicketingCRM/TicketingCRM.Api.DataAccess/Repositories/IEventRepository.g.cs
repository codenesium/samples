using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
	public partial interface IEventRepository
	{
		Task<Event> Create(Event item);

		Task Update(Event item);

		Task Delete(int id);

		Task<Event> Get(int id);

		Task<List<Event>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Event>> ByCityId(int cityId, int limit = int.MaxValue, int offset = 0);

		Task<City> CityByCityId(int cityId);
	}
}

/*<Codenesium>
    <Hash>71e1e11aa6f92453476880b7365a0880</Hash>
</Codenesium>*/