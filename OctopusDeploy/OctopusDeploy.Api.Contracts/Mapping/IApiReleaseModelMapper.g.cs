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
    <Hash>a777d20461ff180f3ad1c139ffd3e5fc</Hash>
</Codenesium>*/