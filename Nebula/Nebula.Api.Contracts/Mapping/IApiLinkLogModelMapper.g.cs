using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public partial interface IApiLinkLogModelMapper
	{
		ApiLinkLogResponseModel MapRequestToResponse(
			int id,
			ApiLinkLogRequestModel request);

		ApiLinkLogRequestModel MapResponseToRequest(
			ApiLinkLogResponseModel response);

		JsonPatchDocument<ApiLinkLogRequestModel> CreatePatch(ApiLinkLogRequestModel model);
	}
}

/*<Codenesium>
    <Hash>5815c730343a40ed64d93d15c3cbed8c</Hash>
</Codenesium>*/