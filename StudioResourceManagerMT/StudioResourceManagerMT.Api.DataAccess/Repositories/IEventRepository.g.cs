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

		Task<List<Event>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<EventStatu> EventStatuByEventStatusId(int eventStatusId);
	}
}

/*<Codenesium>
    <Hash>254a5339ac624d68f1804ce3e5778460</Hash>
</Codenesium>*/