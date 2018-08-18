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
    <Hash>fec5b46f614b00ee086c474c77bbc1ce</Hash>
</Codenesium>*/