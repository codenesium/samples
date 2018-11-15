using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.DataAccess
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
    <Hash>e68662d977fe2d15b5bfe1b2f43d9fd2</Hash>
</Codenesium>*/