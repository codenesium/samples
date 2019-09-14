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
			int id,
			ApiSpaceSpaceFeatureServerRequestModel request);

		ApiSpaceSpaceFeatureServerRequestModel MapServerResponseToRequest(
			ApiSpaceSpaceFeatureServerResponseModel response);

		ApiSpaceSpaceFeatureClientRequestModel MapServerResponseToClientRequest(
			ApiSpaceSpaceFeatureServerResponseModel response);

		JsonPatchDocument<ApiSpaceSpaceFeatureServerRequestModel> CreatePatch(ApiSpaceSpaceFeatureServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>92c6b2c09230e1d4cb83cea42d3b0e27</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/