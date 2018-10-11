using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.DataAccess
{
	public partial interface IEventStatusRepository
	{
		Task<EventStatus> Create(EventStatus item);

		Task Update(EventStatus item);

		Task Delete(int id);

		Task<EventStatus> Get(int id);

		Task<List<EventStatus>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Event>> Events(int eventStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>9ba3b2491762c7f886349dac4bf3f30e</Hash>
</Codenesium>*/