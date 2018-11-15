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

		Task<List<Tweet>> TweetsByLocationId(int locationId, int limit = int.MaxValue, int offset = 0);

		Task<List<User>> UsersByLocationLocationId(int locationLocationId, int limit = int.MaxValue, int offset = 0);

		Task<List<Location>> ByUserUserId(int userUserId, int limit = int.MaxValue, int offset = 0);

		Task<Tweet> CreateTweet(Tweet item);

		Task DeleteTweet(Tweet item);
	}
}

/*<Codenesium>
    <Hash>c364e77dff887c3d4e2d1e2f5879ea56</Hash>
</Codenesium>*/