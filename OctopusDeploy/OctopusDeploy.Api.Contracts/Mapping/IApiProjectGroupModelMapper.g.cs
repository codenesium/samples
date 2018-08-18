using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiProjectGroupModelMapper
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
    <Hash>d2a7b4e06c0fe41d8d81c35fb1289b1a</Hash>
</Codenesium>*/