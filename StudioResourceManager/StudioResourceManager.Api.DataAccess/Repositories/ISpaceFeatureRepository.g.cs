using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.DataAccess
{
	public partial interface ISpaceFeatureRepository
	{
		Task<SpaceFeature> Create(SpaceFeature item);

		Task Update(SpaceFeature item);

		Task Delete(int id);

		Task<SpaceFeature> Get(int id);

		Task<List<SpaceFeature>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<SpaceSpaceFeature>> SpaceSpaceFeatures(int spaceFeatureId, int limit = int.MaxValue, int offset = 0);

		Task<List<SpaceFeature>> BySpaceId(int spaceId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>37714b86ed6a531d2ac88559ef7368d4</Hash>
</Codenesium>*/