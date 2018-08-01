using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public interface IApiSpaceModelMapper
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
    <Hash>8faa012039e2451ef277e73bee3de0b3</Hash>
</Codenesium>*/