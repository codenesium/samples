using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ISpaceXSpaceFeatureRepository
	{
		Task<POCOSpaceXSpaceFeature> Create(ApiSpaceXSpaceFeatureModel model);

		Task Update(int id,
		            ApiSpaceXSpaceFeatureModel model);

		Task Delete(int id);

		Task<POCOSpaceXSpaceFeature> Get(int id);

		Task<List<POCOSpaceXSpaceFeature>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>004584f9dca16c55f4211a43595d817f</Hash>
</Codenesium>*/