using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiReleaseModelMapper
	{
		ApiReleaseResponseModel MapRequestToResponse(
			string id,
			ApiReleaseRequestModel request);

		ApiReleaseRequestModel MapResponseToRequest(
			ApiReleaseResponseModel response);

		JsonPatchDocument<ApiReleaseRequestModel> CreatePatch(ApiReleaseRequestModel model);
	}
}

/*<Codenesium>
    <Hash>5d5e8766275c7bf71b013506fe63babf</Hash>
</Codenesium>*/