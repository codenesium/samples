using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial interface IApiStudioModelMapper
	{
		ApiStudioResponseModel MapRequestToResponse(
			int id,
			ApiStudioRequestModel request);

		ApiStudioRequestModel MapResponseToRequest(
			ApiStudioResponseModel response);

		JsonPatchDocument<ApiStudioRequestModel> CreatePatch(ApiStudioRequestModel model);
	}
}

/*<Codenesium>
    <Hash>14c0563d878ae90c5c3ca550bbacb9b7</Hash>
</Codenesium>*/