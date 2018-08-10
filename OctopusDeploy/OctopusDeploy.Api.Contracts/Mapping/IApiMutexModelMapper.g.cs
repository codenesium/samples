using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiMutexModelMapper
	{
		ApiMutexResponseModel MapRequestToResponse(
			string id,
			ApiMutexRequestModel request);

		ApiMutexRequestModel MapResponseToRequest(
			ApiMutexResponseModel response);

		JsonPatchDocument<ApiMutexRequestModel> CreatePatch(ApiMutexRequestModel model);
	}
}

/*<Codenesium>
    <Hash>e0ff337df3cccf0d57ad9123845caaca</Hash>
</Codenesium>*/