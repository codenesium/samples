using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiOctopusServerNodeModelMapper
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
    <Hash>12e47d4818b044ee120fcae43c27dcde</Hash>
</Codenesium>*/