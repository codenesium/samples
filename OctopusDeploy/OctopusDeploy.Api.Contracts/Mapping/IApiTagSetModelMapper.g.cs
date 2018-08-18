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
    <Hash>69e95024702f2bb2cb00f76f9542d247</Hash>
</Codenesium>*/