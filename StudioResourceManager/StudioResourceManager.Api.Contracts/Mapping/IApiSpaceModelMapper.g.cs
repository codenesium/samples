using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial interface IApiSpaceModelMapper
	{
		ApiSpaceResponseModel MapRequestToResponse(
			int id,
			ApiSpaceRequestModel request);

		ApiSpaceRequestModel MapResponseToRequest(
			ApiSpaceResponseModel response);

		JsonPatchDocument<ApiSpaceRequestModel> CreatePatch(ApiSpaceRequestModel model);
	}
}

/*<Codenesium>
    <Hash>96eb676b86b1f9b2a8ca39c3511e7a65</Hash>
</Codenesium>*/