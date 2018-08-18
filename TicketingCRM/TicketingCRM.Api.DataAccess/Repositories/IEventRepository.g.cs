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

		Task<List<Event>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Event>> ByCityId(int cityId, int limit = int.MaxValue, int offset = 0);

		Task<City> GetCity(int cityId);
	}
}

/*<Codenesium>
    <Hash>6b6924a0202f8e6cea324aebcd224c7d</Hash>
</Codenesium>*/