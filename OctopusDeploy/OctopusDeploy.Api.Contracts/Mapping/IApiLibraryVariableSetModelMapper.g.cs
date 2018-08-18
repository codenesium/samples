using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiLibraryVariableSetModelMapper
	{
		ApiLibraryVariableSetResponseModel MapRequestToResponse(
			string id,
			ApiLibraryVariableSetRequestModel request);

		ApiLibraryVariableSetRequestModel MapResponseToRequest(
			ApiLibraryVariableSetResponseModel response);

		JsonPatchDocument<ApiLibraryVariableSetRequestModel> CreatePatch(ApiLibraryVariableSetRequestModel model);
	}
}

/*<Codenesium>
    <Hash>7affa6bd7697668ee2af42f761b131c8</Hash>
</Codenesium>*/