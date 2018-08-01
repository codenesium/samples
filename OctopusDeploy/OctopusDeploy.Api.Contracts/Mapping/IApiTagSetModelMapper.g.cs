using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiTagSetModelMapper
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
    <Hash>2b8c6812d49e449ddd9aaa0ffc8adbaa</Hash>
</Codenesium>*/