using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOSpaceXSpaceFeature
	{
		Task<CreateResponse<POCOSpaceXSpaceFeature>> Create(
			ApiSpaceXSpaceFeatureModel model);

		Task<ActionResponse> Update(int id,
		                            ApiSpaceXSpaceFeatureModel model);

		Task<ActionResponse> Delete(int id);

		Task<POCOSpaceXSpaceFeature> Get(int id);

		Task<List<POCOSpaceXSpaceFeature>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e58bc49f1cd22669df34d8d14e51968f</Hash>
</Codenesium>*/