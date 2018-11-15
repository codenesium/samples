using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	public partial interface IEventRepository
	{
		Task<Event> Create(Event item);

		Task Update(Event item);

		Task Delete(int id);

		Task<Event> Get(int id);

		Task<List<Event>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Event>> ByEventStatusId(int eventStatusId, int limit = int.MaxValue, int offset = 0);

		Task<EventStatu> EventStatuByEventStatusId(int eventStatusId);
	}
}

/*<Codenesium>
    <Hash>a0dc791dd344998f0df23875fe4fe79b</Hash>
</Codenesium>*/