using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ISpaceFeatureRepository
	{
		POCOSpaceFeature Create(ApiSpaceFeatureModel model);

		void Update(int id,
		            ApiSpaceFeatureModel model);

		void Delete(int id);

		POCOSpaceFeature Get(int id);

		List<POCOSpaceFeature> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c8d31399cabaab61debdc536e9372b97</Hash>
</Codenesium>*/