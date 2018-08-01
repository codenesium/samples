using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiProjectModelMapper
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
    <Hash>d88d89a9faf20a62cf04215effdbfe08</Hash>
</Codenesium>*/