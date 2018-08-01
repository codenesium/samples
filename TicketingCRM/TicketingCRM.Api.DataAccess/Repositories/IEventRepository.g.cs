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
    <Hash>95005b8362f7d9b5a8e08467a80ae2b1</Hash>
</Codenesium>*/