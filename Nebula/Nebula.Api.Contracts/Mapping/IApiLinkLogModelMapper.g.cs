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
    <Hash>a33444c14bc664af4ab5890405278abc</Hash>
</Codenesium>*/