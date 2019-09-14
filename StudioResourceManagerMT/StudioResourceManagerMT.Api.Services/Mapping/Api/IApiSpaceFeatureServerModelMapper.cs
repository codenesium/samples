using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>a6d4117d7b36124ebe874889d7c490a2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/