using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
	public interface ISpaceXSpaceFeatureRepository
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
    <Hash>e6491085d556e679be288f3e69a39ea9</Hash>
</Codenesium>*/