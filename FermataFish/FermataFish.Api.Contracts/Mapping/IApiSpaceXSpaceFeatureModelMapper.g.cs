using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public partial interface IApiSpaceXSpaceFeatureModelMapper
	{
		ApiSpaceXSpaceFeatureResponseModel MapRequestToResponse(
			int id,
			ApiSpaceXSpaceFeatureRequestModel request);

		ApiSpaceXSpaceFeatureRequestModel MapResponseToRequest(
			ApiSpaceXSpaceFeatureResponseModel response);

		JsonPatchDocument<ApiSpaceXSpaceFeatureRequestModel> CreatePatch(ApiSpaceXSpaceFeatureRequestModel model);
	}
}

/*<Codenesium>
    <Hash>b1b64f0d2e21985309b0ddfee4be0341</Hash>
</Codenesium>*/