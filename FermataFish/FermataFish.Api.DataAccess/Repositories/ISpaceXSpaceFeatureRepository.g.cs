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

		Task<List<SpaceXSpaceFeature>> ByStudioId(int studioId, int limit = int.MaxValue, int offset = 0);

		Task<SpaceFeature> GetSpaceFeature(int spaceFeatureId);

		Task<Space> GetSpace(int spaceId);

		Task<Studio> GetStudio(int studioId);
	}
}

/*<Codenesium>
    <Hash>c7531a0ad637d5d09f397b60d3efb7ca</Hash>
</Codenesium>*/