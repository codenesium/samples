using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public partial interface IApiPostLinkModelMapper
	{
		ApiPostLinkResponseModel MapRequestToResponse(
			int id,
			ApiPostLinkRequestModel request);

		ApiPostLinkRequestModel MapResponseToRequest(
			ApiPostLinkResponseModel response);

		JsonPatchDocument<ApiPostLinkRequestModel> CreatePatch(ApiPostLinkRequestModel model);
	}
}

/*<Codenesium>
    <Hash>8af68cf43b4e4b468dda68d463ed6494</Hash>
</Codenesium>*/