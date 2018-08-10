using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiProjectModelMapper
	{
		ApiProjectResponseModel MapRequestToResponse(
			string id,
			ApiProjectRequestModel request);

		ApiProjectRequestModel MapResponseToRequest(
			ApiProjectResponseModel response);

		JsonPatchDocument<ApiProjectRequestModel> CreatePatch(ApiProjectRequestModel model);
	}
}

/*<Codenesium>
    <Hash>c9de7facd067a9c99daf36cf9f630957</Hash>
</Codenesium>*/