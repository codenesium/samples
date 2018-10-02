using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public partial interface IApiUserModelMapper
	{
		ApiUserResponseModel MapRequestToResponse(
			int id,
			ApiUserRequestModel request);

		ApiUserRequestModel MapResponseToRequest(
			ApiUserResponseModel response);

		JsonPatchDocument<ApiUserRequestModel> CreatePatch(ApiUserRequestModel model);
	}
}

/*<Codenesium>
    <Hash>ae020938adcbaafcea17474d03e2f242</Hash>
</Codenesium>*/