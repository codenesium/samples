using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.DataAccess
{
	public partial interface ISpaceSpaceFeatureRepository
	{
		Task<SpaceSpaceFeature> Create(SpaceSpaceFeature item);

		Task Update(SpaceSpaceFeature item);

		Task Delete(int id);

		Task<SpaceSpaceFeature> Get(int id);

		Task<List<SpaceSpaceFeature>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<SpaceSpaceFeature>> BySpaceFeatureId(int spaceFeatureId, int limit = int.MaxValue, int offset = 0);

		Task<List<SpaceSpaceFeature>> BySpaceId(int spaceId, int limit = int.MaxValue, int offset = 0);

		Task<SpaceFeature> SpaceFeatureBySpaceFeatureId(int spaceFeatureId);

		Task<Space> SpaceBySpaceId(int spaceId);
	}
}

/*<Codenesium>
    <Hash>8d942a35fb9cbce23b9e99f70988c234</Hash>
</Codenesium>*/