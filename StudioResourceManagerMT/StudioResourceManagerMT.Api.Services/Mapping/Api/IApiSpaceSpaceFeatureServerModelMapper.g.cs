using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IApiSpaceSpaceFeatureServerModelMapper
	{
		ApiSpaceSpaceFeatureServerResponseModel MapServerRequestToResponse(
			int spaceId,
			ApiSpaceSpaceFeatureServerRequestModel request);

		ApiSpaceSpaceFeatureServerRequestModel MapServerResponseToRequest(
			ApiSpaceSpaceFeatureServerResponseModel response);

		ApiSpaceSpaceFeatureClientRequestModel MapServerResponseToClientRequest(
			ApiSpaceSpaceFeatureServerResponseModel response);

		JsonPatchDocument<ApiSpaceSpaceFeatureServerRequestModel> CreatePatch(ApiSpaceSpaceFeatureServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>6bc44b70ab126282039e8a0e8c478e66</Hash>
</Codenesium>*/