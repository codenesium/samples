using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
	public interface ISpaceXSpaceFeatureService
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
    <Hash>191d6f5bf4c4cdf01cae85ab081baf1d</Hash>
</Codenesium>*/