using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiProjectGroupModelMapper
	{
		ApiProjectGroupResponseModel MapRequestToResponse(
			string id,
			ApiProjectGroupRequestModel request);

		ApiProjectGroupRequestModel MapResponseToRequest(
			ApiProjectGroupResponseModel response);

		JsonPatchDocument<ApiProjectGroupRequestModel> CreatePatch(ApiProjectGroupRequestModel model);
	}
}

/*<Codenesium>
    <Hash>76b1d6b3cc344cc5dd32491dd99e09b3</Hash>
</Codenesium>*/