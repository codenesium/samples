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

		Task<List<Location>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Tweet>> TweetsByLocationId(int locationId, int limit = int.MaxValue, int offset = 0);

		Task<List<User>> UsersByLocationLocationId(int locationLocationId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d17e92232a31ca9e4ca4b239dd7c72f8</Hash>
</Codenesium>*/