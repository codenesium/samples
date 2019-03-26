using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	public partial interface IEventStatuRepository
	{
		Task<EventStatu> Create(EventStatu item);

		Task Update(EventStatu item);

		Task Delete(int id);

		Task<EventStatu> Get(int id);

		Task<List<EventStatu>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Event>> EventsByEventStatusId(int eventStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c76747446781fc7c134c1ea5ee82a1c2</Hash>
</Codenesium>*/