using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.DataAccess
{
	public partial interface IEventRepository
	{
		Task<Event> Create(Event item);

		Task Update(Event item);

		Task Delete(int id);

		Task<Event> Get(int id);

		Task<List<Event>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Event>> ByEventStatusId(int eventStatusId, int limit = int.MaxValue, int offset = 0);

		Task<EventStatus> EventStatusByEventStatusId(int eventStatusId);
	}
}

/*<Codenesium>
    <Hash>34c72baddebff5622995f17cab55ba48</Hash>
</Codenesium>*/