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
	}
}

/*<Codenesium>
    <Hash>ddd702fe6cace1b174726c3ae21e4cb0</Hash>
</Codenesium>*/