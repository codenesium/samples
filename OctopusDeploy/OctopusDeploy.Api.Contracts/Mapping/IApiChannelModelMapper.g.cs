using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiChannelModelMapper
	{
		ApiChannelResponseModel MapRequestToResponse(
			string id,
			ApiChannelRequestModel request);

		ApiChannelRequestModel MapResponseToRequest(
			ApiChannelResponseModel response);

		JsonPatchDocument<ApiChannelRequestModel> CreatePatch(ApiChannelRequestModel model);
	}
}

/*<Codenesium>
    <Hash>de71c117b5cf0422db600cf75a8555c5</Hash>
</Codenesium>*/