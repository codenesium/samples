using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ISpaceFeatureRepository
	{
		Task<POCOSpaceFeature> Create(ApiSpaceFeatureModel model);

		Task Update(int id,
		            ApiSpaceFeatureModel model);

		Task Delete(int id);

		Task<POCOSpaceFeature> Get(int id);

		Task<List<POCOSpaceFeature>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>cbda9f7674fe05500834cecb1393d74f</Hash>
</Codenesium>*/