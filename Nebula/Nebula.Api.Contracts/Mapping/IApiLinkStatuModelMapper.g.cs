using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public partial interface IApiLinkStatuModelMapper
	{
		ApiLinkStatuResponseModel MapRequestToResponse(
			int id,
			ApiLinkStatuRequestModel request);

		ApiLinkStatuRequestModel MapResponseToRequest(
			ApiLinkStatuResponseModel response);

		JsonPatchDocument<ApiLinkStatuRequestModel> CreatePatch(ApiLinkStatuRequestModel model);
	}
}

/*<Codenesium>
    <Hash>3244e001b27cdb637544497911301282</Hash>
</Codenesium>*/