using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
	public partial interface ISpaceXSpaceFeatureRepository
	{
		Task<SpaceXSpaceFeature> Create(SpaceXSpaceFeature item);

		Task Update(SpaceXSpaceFeature item);

		Task Delete(int id);

		Task<SpaceXSpaceFeature> Get(int id);

		Task<List<SpaceXSpaceFeature>> All(int limit = int.MaxValue, int offset = 0);

		Task<SpaceFeature> GetSpaceFeature(int spaceFeatureId);

		Task<Space> GetSpace(int spaceId);
	}
}

/*<Codenesium>
    <Hash>e22063b842c85c6dca5ec89eec4d6410</Hash>
</Codenesium>*/