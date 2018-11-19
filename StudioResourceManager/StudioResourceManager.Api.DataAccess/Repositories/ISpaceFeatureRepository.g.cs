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

		Task<List<SpaceFeature>> BySpaceId(int spaceId, int limit = int.MaxValue, int offset = 0);

		Task<SpaceSpaceFeature> CreateSpaceSpaceFeature(SpaceSpaceFeature item);

		Task DeleteSpaceSpaceFeature(SpaceSpaceFeature item);
	}
}

/*<Codenesium>
    <Hash>a82dbbde18b7a00e93b1ec54b066875a</Hash>
</Codenesium>*/