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

		Task Delete(int spaceId);

		Task<SpaceSpaceFeature> Get(int spaceId);

		Task<List<SpaceSpaceFeature>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<SpaceFeature> SpaceFeatureBySpaceFeatureId(int spaceFeatureId);

		Task<Space> SpaceBySpaceId(int spaceId);
	}
}

/*<Codenesium>
    <Hash>0f45363512996ad666df75630dcffa37</Hash>
</Codenesium>*/