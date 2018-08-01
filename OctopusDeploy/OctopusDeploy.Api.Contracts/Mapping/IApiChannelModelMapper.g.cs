using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiChannelModelMapper
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
    <Hash>9df41723aac34aca89e0ec3990be463a</Hash>
</Codenesium>*/