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
    <Hash>e7ef352ebf7024aa50b624bc8e20fef7</Hash>
</Codenesium>*/