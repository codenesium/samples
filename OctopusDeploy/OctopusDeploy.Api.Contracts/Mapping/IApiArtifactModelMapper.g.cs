using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiArtifactModelMapper
	{
		ApiArtifactResponseModel MapRequestToResponse(
			string id,
			ApiArtifactRequestModel request);

		ApiArtifactRequestModel MapResponseToRequest(
			ApiArtifactResponseModel response);

		JsonPatchDocument<ApiArtifactRequestModel> CreatePatch(ApiArtifactRequestModel model);
	}
}

/*<Codenesium>
    <Hash>bc8714f565ca0de87b883c943b39ddfe</Hash>
</Codenesium>*/