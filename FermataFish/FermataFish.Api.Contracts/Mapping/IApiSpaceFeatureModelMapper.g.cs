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
    <Hash>8c4577561d73253ea9e2a2a4dfa854a1</Hash>
</Codenesium>*/