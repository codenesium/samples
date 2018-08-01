using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiReleaseModelMapper
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
    <Hash>9e4757485d494793b7228f7efb626e8f</Hash>
</Codenesium>*/