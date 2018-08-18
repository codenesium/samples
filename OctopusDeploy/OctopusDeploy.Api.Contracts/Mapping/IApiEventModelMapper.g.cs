using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiEventModelMapper
	{
		ApiEventResponseModel MapRequestToResponse(
			string id,
			ApiEventRequestModel request);

		ApiEventRequestModel MapResponseToRequest(
			ApiEventResponseModel response);

		JsonPatchDocument<ApiEventRequestModel> CreatePatch(ApiEventRequestModel model);
	}
}

/*<Codenesium>
    <Hash>df94a917373ebe14f4ff43401242a6f9</Hash>
</Codenesium>*/