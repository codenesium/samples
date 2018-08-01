using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiUserModelMapper
	{
		ApiUserResponseModel MapRequestToResponse(
			string id,
			ApiUserRequestModel request);

		ApiUserRequestModel MapResponseToRequest(
			ApiUserResponseModel response);

		JsonPatchDocument<ApiUserRequestModel> CreatePatch(ApiUserRequestModel model);
	}
}

/*<Codenesium>
    <Hash>d84476c99ebf74cdaf2203dd34b926f3</Hash>
</Codenesium>*/