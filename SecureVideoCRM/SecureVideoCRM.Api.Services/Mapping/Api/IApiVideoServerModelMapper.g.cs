using Microsoft.AspNetCore.JsonPatch;
using SecureVideoCRMNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Services
{
	public partial interface IApiVideoServerModelMapper
	{
		ApiVideoServerResponseModel MapServerRequestToResponse(
			int id,
			ApiVideoServerRequestModel request);

		ApiVideoServerRequestModel MapServerResponseToRequest(
			ApiVideoServerResponseModel response);

		ApiVideoClientRequestModel MapServerResponseToClientRequest(
			ApiVideoServerResponseModel response);

		JsonPatchDocument<ApiVideoServerRequestModel> CreatePatch(ApiVideoServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>325f7bd8531f6b33f19310f5f1418e2c</Hash>
</Codenesium>*/