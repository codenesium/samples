using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public interface IApiLinkStatusModelMapper
	{
		ApiLinkStatusResponseModel MapRequestToResponse(
			int id,
			ApiLinkStatusRequestModel request);

		ApiLinkStatusRequestModel MapResponseToRequest(
			ApiLinkStatusResponseModel response);

		JsonPatchDocument<ApiLinkStatusRequestModel> CreatePatch(ApiLinkStatusRequestModel model);
	}
}

/*<Codenesium>
    <Hash>3892546d544788063ccda2c8b9154dcc</Hash>
</Codenesium>*/