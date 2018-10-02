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

		Task<List<SpaceSpaceFeature>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<SpaceSpaceFeature>> BySpaceFeatureId(int spaceFeatureId, int limit = int.MaxValue, int offset = 0);

		Task<List<SpaceSpaceFeature>> BySpaceId(int spaceId, int limit = int.MaxValue, int offset = 0);

		Task<SpaceFeature> GetSpaceFeature(int spaceFeatureId);

		Task<Space> GetSpace(int spaceId);
	}
}

/*<Codenesium>
    <Hash>5e5a7f3d8363cdec937d01d1722a1687</Hash>
</Codenesium>*/