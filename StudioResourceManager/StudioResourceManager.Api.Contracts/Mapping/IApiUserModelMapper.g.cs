using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial interface IApiUserModelMapper
	{
		ApiUserResponseModel MapRequestToResponse(
			int id,
			ApiUserRequestModel request);

		ApiUserRequestModel MapResponseToRequest(
			ApiUserResponseModel response);

		JsonPatchDocument<ApiUserRequestModel> CreatePatch(ApiUserRequestModel model);
	}
}

/*<Codenesium>
    <Hash>d3092d988943af1a19b1bcad29a3fcb4</Hash>
</Codenesium>*/