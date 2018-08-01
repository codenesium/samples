using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiLibraryVariableSetModelMapper
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
    <Hash>6031a4572faebf4dc94dd55cc87da8a5</Hash>
</Codenesium>*/