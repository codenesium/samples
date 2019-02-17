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

		Task<List<Event>> ByEventStatusId(int eventStatusId, int limit = int.MaxValue, int offset = 0);

		Task<EventStatu> EventStatuByEventStatusId(int eventStatusId);
	}
}

/*<Codenesium>
    <Hash>37195ddaf2b8fc9228b1e3e7a844c4d1</Hash>
</Codenesium>*/