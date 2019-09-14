using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IApiSpaceFeatureServerModelMapper
	{
		ApiSpaceFeatureServerResponseModel MapServerRequestToResponse(
			int id,
			ApiSpaceFeatureServerRequestModel request);

		ApiSpaceFeatureServerRequestModel MapServerResponseToRequest(
			ApiSpaceFeatureServerResponseModel response);

		ApiSpaceFeatureClientRequestModel MapServerResponseToClientRequest(
			ApiSpaceFeatureServerResponseModel response);

		JsonPatchDocument<ApiSpaceFeatureServerRequestModel> CreatePatch(ApiSpaceFeatureServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>601c47c579a724e7595c07db1d9f9393</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/