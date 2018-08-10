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
    <Hash>80a73dcb35c54cb7b27d68e19a25718a</Hash>
</Codenesium>*/