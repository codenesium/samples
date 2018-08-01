using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiEventModelMapper
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
    <Hash>3c27ca3428cf938b15436c5ed4ff0f1b</Hash>
</Codenesium>*/