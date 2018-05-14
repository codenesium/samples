using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ISpaceXSpaceFeatureRepository
	{
		POCOSpaceXSpaceFeature Create(ApiSpaceXSpaceFeatureModel model);

		void Update(int id,
		            ApiSpaceXSpaceFeatureModel model);

		void Delete(int id);

		POCOSpaceXSpaceFeature Get(int id);

		List<POCOSpaceXSpaceFeature> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6701606bf77c990581d2bd83cb05b0cb</Hash>
</Codenesium>*/