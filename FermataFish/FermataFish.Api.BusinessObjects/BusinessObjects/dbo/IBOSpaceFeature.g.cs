using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOSpaceFeature
	{
		Task<CreateResponse<POCOSpaceFeature>> Create(
			ApiSpaceFeatureModel model);

		Task<ActionResponse> Update(int id,
		                            ApiSpaceFeatureModel model);

		Task<ActionResponse> Delete(int id);

		Task<POCOSpaceFeature> Get(int id);

		Task<List<POCOSpaceFeature>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>45973acaa4694baf31d781d84c525575</Hash>
</Codenesium>*/