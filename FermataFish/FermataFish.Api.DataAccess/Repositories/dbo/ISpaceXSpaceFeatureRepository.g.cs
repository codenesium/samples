using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ISpaceXSpaceFeatureRepository
	{
		int Create(SpaceXSpaceFeatureModel model);

		void Update(int id,
		            SpaceXSpaceFeatureModel model);

		void Delete(int id);

		POCOSpaceXSpaceFeature Get(int id);

		List<POCOSpaceXSpaceFeature> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>18cfc39a64e61f35c021f188e2f4fdaa</Hash>
</Codenesium>*/