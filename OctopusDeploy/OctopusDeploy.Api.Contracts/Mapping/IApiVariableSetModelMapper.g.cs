using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiVariableSetModelMapper
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
    <Hash>4a46ad782967f995b3740b9d21b83375</Hash>
</Codenesium>*/