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

		Task<List<SpaceSpaceFeature>> SpaceSpaceFeaturesBySpaceFeatureId(int spaceFeatureId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>962a228b530ec54fd31b7ddc49a53a4a</Hash>
</Codenesium>*/