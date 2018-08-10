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
    <Hash>343cba204a33680cc1da5f136ee08459</Hash>
</Codenesium>*/