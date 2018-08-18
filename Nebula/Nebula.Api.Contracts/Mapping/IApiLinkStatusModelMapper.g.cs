using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public partial interface IApiLinkStatusModelMapper
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
    <Hash>2d19fce1842a38f400069f27c13acb13</Hash>
</Codenesium>*/