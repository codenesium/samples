using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public partial interface IApiLinkModelMapper
	{
		ApiLinkResponseModel MapRequestToResponse(
			int id,
			ApiLinkRequestModel request);

		ApiLinkRequestModel MapResponseToRequest(
			ApiLinkResponseModel response);

		JsonPatchDocument<ApiLinkRequestModel> CreatePatch(ApiLinkRequestModel model);
	}
}

/*<Codenesium>
    <Hash>822de4680bc3b09d00b02669a6330317</Hash>
</Codenesium>*/