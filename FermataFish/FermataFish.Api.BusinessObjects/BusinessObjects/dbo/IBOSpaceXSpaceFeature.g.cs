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
		Task<CreateResponse<ApiSpaceXSpaceFeatureResponseModel>> Create(
			ApiSpaceXSpaceFeatureRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiSpaceXSpaceFeatureRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSpaceXSpaceFeatureResponseModel> Get(int id);

		Task<List<ApiSpaceXSpaceFeatureResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>cd9046a2bdb865f205bed277d1169ce8</Hash>
</Codenesium>*/