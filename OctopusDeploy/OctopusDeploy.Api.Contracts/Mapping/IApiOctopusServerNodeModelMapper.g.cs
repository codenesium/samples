using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiOctopusServerNodeModelMapper
	{
		ApiOctopusServerNodeResponseModel MapRequestToResponse(
			string id,
			ApiOctopusServerNodeRequestModel request);

		ApiOctopusServerNodeRequestModel MapResponseToRequest(
			ApiOctopusServerNodeResponseModel response);

		JsonPatchDocument<ApiOctopusServerNodeRequestModel> CreatePatch(ApiOctopusServerNodeRequestModel model);
	}
}

/*<Codenesium>
    <Hash>b0f323f11fc49829ecfa432aa8eb62b5</Hash>
</Codenesium>*/