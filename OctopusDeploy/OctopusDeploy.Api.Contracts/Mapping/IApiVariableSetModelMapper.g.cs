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
    <Hash>e9a33c0816527e7208d9f1a150bbb24a</Hash>
</Codenesium>*/