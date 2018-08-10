using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiTagSetModelMapper
	{
		ApiTagSetResponseModel MapRequestToResponse(
			string id,
			ApiTagSetRequestModel request);

		ApiTagSetRequestModel MapResponseToRequest(
			ApiTagSetResponseModel response);

		JsonPatchDocument<ApiTagSetRequestModel> CreatePatch(ApiTagSetRequestModel model);
	}
}

/*<Codenesium>
    <Hash>fb8997c6e5c11cecd31c56d7e074ae06</Hash>
</Codenesium>*/