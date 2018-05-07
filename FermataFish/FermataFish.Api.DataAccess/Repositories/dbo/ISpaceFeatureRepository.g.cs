using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ISpaceFeatureRepository
	{
		int Create(SpaceFeatureModel model);

		void Update(int id,
		            SpaceFeatureModel model);

		void Delete(int id);

		POCOSpaceFeature Get(int id);

		List<POCOSpaceFeature> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>494973259f72fdbedfd16ab39e9211d1</Hash>
</Codenesium>*/