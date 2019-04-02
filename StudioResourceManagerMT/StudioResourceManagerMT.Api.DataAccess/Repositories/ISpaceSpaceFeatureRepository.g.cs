using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	public partial interface ISpaceSpaceFeatureRepository
	{
		Task<SpaceSpaceFeature> Create(SpaceSpaceFeature item);

		Task Update(SpaceSpaceFeature item);

		Task Delete(int id);

		Task<SpaceSpaceFeature> Get(int id);

		Task<List<SpaceSpaceFeature>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<SpaceFeature> SpaceFeatureBySpaceFeatureId(int spaceFeatureId);

		Task<Space> SpaceBySpaceId(int spaceId);
	}
}

/*<Codenesium>
    <Hash>f174a39c6bc029297fd7b7ba48c4eea4</Hash>
</Codenesium>*/