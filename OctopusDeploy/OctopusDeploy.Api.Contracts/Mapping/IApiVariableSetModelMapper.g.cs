using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiVariableSetModelMapper
	{
		ApiVariableSetResponseModel MapRequestToResponse(
			string id,
			ApiVariableSetRequestModel request);

		ApiVariableSetRequestModel MapResponseToRequest(
			ApiVariableSetResponseModel response);

		JsonPatchDocument<ApiVariableSetRequestModel> CreatePatch(ApiVariableSetRequestModel model);
	}
}

/*<Codenesium>
    <Hash>c183b4d0322982bdbd3f457a1947437c</Hash>
</Codenesium>*/