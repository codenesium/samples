using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiMutexModelMapper
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
    <Hash>a4ceaeaf9c17339d82a6f9f2c8f9d573</Hash>
</Codenesium>*/