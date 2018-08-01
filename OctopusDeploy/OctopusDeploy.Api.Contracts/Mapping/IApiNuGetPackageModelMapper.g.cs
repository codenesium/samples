using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiNuGetPackageModelMapper
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
    <Hash>b99ab54f6c4270bcf031b3c1c2706cb8</Hash>
</Codenesium>*/