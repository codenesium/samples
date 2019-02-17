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
	}
}

/*<Codenesium>
    <Hash>58627e30bc0f69ac72946c0b8293d6f3</Hash>
</Codenesium>*/