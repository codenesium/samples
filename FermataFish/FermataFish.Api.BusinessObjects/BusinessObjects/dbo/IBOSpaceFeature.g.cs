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
		Task<CreateResponse<ApiSpaceFeatureResponseModel>> Create(
			ApiSpaceFeatureRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiSpaceFeatureRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSpaceFeatureResponseModel> Get(int id);

		Task<List<ApiSpaceFeatureResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3641e69fd0a99053a32154d0ee107f72</Hash>
</Codenesium>*/