using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiArtifactModelMapper
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
    <Hash>f198ffefd1efb4bd646a4469be28aab8</Hash>
</Codenesium>*/