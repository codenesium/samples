using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ISpaceXSpaceFeatureRepository
	{
		POCOSpaceXSpaceFeature Create(SpaceXSpaceFeatureModel model);

		void Update(int id,
		            SpaceXSpaceFeatureModel model);

		void Delete(int id);

		POCOSpaceXSpaceFeature Get(int id);

		List<POCOSpaceXSpaceFeature> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>04e2e8baf931b942ab8582d9ea24dd38</Hash>
</Codenesium>*/