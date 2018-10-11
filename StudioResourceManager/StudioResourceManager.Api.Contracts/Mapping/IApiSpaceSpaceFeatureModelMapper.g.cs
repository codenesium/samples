using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial interface IApiSpaceSpaceFeatureModelMapper
	{
		ApiSpaceSpaceFeatureResponseModel MapRequestToResponse(
			int spaceId,
			ApiSpaceSpaceFeatureRequestModel request);

		ApiSpaceSpaceFeatureRequestModel MapResponseToRequest(
			ApiSpaceSpaceFeatureResponseModel response);

		JsonPatchDocument<ApiSpaceSpaceFeatureRequestModel> CreatePatch(ApiSpaceSpaceFeatureRequestModel model);
	}
}

/*<Codenesium>
    <Hash>3005d7eb0665de7f1956b18a4a66f027</Hash>
</Codenesium>*/