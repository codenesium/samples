using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	public partial interface IEventStatusRepository
	{
		Task<EventStatus> Create(EventStatus item);

		Task Update(EventStatus item);

		Task Delete(int id);

		Task<EventStatus> Get(int id);

		Task<List<EventStatus>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Event>> EventsByEventStatusId(int eventStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>59e13ec59ffa7a8e2b3a5bb35b1e7b93</Hash>
</Codenesium>*/