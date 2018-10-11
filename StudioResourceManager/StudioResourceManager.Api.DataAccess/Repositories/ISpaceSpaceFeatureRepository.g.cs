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

		Task Delete(int spaceId);

		Task<SpaceSpaceFeature> Get(int spaceId);

		Task<List<SpaceSpaceFeature>> All(int limit = int.MaxValue, int offset = 0);

		Task<SpaceFeature> SpaceFeatureBySpaceFeatureId(int spaceFeatureId);

		Task<Space> SpaceBySpaceId(int spaceId);
	}
}

/*<Codenesium>
    <Hash>685e2e822ca23588ebd86ce5bb25c8cd</Hash>
</Codenesium>*/