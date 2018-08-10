using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiNuGetPackageModelMapper
	{
		ApiNuGetPackageResponseModel MapRequestToResponse(
			string id,
			ApiNuGetPackageRequestModel request);

		ApiNuGetPackageRequestModel MapResponseToRequest(
			ApiNuGetPackageResponseModel response);

		JsonPatchDocument<ApiNuGetPackageRequestModel> CreatePatch(ApiNuGetPackageRequestModel model);
	}
}

/*<Codenesium>
    <Hash>56a2eee416e620ecb5828a4296048ac5</Hash>
</Codenesium>*/