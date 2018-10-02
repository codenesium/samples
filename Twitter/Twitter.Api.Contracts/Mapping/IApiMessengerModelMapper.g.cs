using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Contracts
{
	public partial interface IApiMessengerModelMapper
	{
		ApiMessengerResponseModel MapRequestToResponse(
			int id,
			ApiMessengerRequestModel request);

		ApiMessengerRequestModel MapResponseToRequest(
			ApiMessengerResponseModel response);

		JsonPatchDocument<ApiMessengerRequestModel> CreatePatch(ApiMessengerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>08abe5b0ea6cf3ab33931919be8710a8</Hash>
</Codenesium>*/