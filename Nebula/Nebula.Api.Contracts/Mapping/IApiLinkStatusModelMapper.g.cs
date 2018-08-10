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
    <Hash>8bccf3bb30d9dcafdcca57d74d00c327</Hash>
</Codenesium>*/