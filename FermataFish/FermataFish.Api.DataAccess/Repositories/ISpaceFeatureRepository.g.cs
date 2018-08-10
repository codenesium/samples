using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
	public partial interface ISpaceFeatureRepository
	{
		Task<SpaceFeature> Create(SpaceFeature item);

		Task Update(SpaceFeature item);

		Task Delete(int id);

		Task<SpaceFeature> Get(int id);

		Task<List<SpaceFeature>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<SpaceXSpaceFeature>> SpaceXSpaceFeatures(int spaceFeatureId, int limit = int.MaxValue, int offset = 0);

		Task<Studio> GetStudio(int studioId);
	}
}

/*<Codenesium>
    <Hash>cb8cc918984d859db760c96803d12d29</Hash>
</Codenesium>*/