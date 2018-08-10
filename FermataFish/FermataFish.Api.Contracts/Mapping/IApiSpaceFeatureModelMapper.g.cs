using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public partial interface IApiSpaceFeatureModelMapper
	{
		ApiSpaceFeatureResponseModel MapRequestToResponse(
			int id,
			ApiSpaceFeatureRequestModel request);

		ApiSpaceFeatureRequestModel MapResponseToRequest(
			ApiSpaceFeatureResponseModel response);

		JsonPatchDocument<ApiSpaceFeatureRequestModel> CreatePatch(ApiSpaceFeatureRequestModel model);
	}
}

/*<Codenesium>
    <Hash>b6be293ef23610546e7afa811dd3bd48</Hash>
</Codenesium>*/