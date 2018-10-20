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

		Task<List<Event>> EventsByEventStatusId(int eventStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>5b76c670d9025f76339b0f845c7bd761</Hash>
</Codenesium>*/