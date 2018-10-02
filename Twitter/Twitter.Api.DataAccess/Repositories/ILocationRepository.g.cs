using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TwitterNS.Api.DataAccess
{
	public partial interface ILocationRepository
	{
		Task<Location> Create(Location item);

		Task Update(Location item);

		Task Delete(int locationId);

		Task<Location> Get(int locationId);

		Task<List<Location>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Tweet>> Tweets(int locationId, int limit = int.MaxValue, int offset = 0);

		Task<List<User>> Users(int locationLocationId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>bdfee26a6514b8d3dcda264c948b6f7e</Hash>
</Codenesium>*/