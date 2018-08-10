using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
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
    <Hash>2c52363b3826cd8fab939da18667577b</Hash>
</Codenesium>*/