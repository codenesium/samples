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

		Task<List<SpaceFeature>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<SpaceSpaceFeature>> SpaceSpaceFeaturesBySpaceFeatureId(int spaceFeatureId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>32525f05e8a209a42c56e8c6578bc92b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/