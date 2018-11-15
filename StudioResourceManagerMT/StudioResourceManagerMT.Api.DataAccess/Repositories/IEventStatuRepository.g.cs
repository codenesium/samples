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

		Task<List<EventStatu>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Event>> EventsByEventStatusId(int eventStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>ae94ed81a3257500a88d3187728f2b4b</Hash>
</Codenesium>*/