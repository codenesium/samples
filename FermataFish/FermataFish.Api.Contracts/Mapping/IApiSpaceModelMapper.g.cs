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
    <Hash>15f97a6ef1c8cb8f35377cbc454dc15f</Hash>
</Codenesium>*/