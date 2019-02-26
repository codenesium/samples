using Microsoft.AspNetCore.JsonPatch;
using SecureVideoCRMNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Services
{
	public partial interface IApiUserServerModelMapper
	{
		ApiUserServerResponseModel MapServerRequestToResponse(
			int id,
			ApiUserServerRequestModel request);

		ApiUserServerRequestModel MapServerResponseToRequest(
			ApiUserServerResponseModel response);

		ApiUserClientRequestModel MapServerResponseToClientRequest(
			ApiUserServerResponseModel response);

		JsonPatchDocument<ApiUserServerRequestModel> CreatePatch(ApiUserServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>e81f7148bf80da4b5c8bc4afef0c282b</Hash>
</Codenesium>*/