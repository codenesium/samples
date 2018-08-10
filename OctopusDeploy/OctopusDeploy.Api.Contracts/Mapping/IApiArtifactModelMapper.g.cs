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
    <Hash>a944877c21b5557b119ed80bdf7944e4</Hash>
</Codenesium>*/