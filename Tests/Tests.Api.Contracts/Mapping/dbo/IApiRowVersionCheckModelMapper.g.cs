using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public partial interface IApiRowVersionCheckModelMapper
	{
		ApiRowVersionCheckResponseModel MapRequestToResponse(
			int id,
			ApiRowVersionCheckRequestModel request);

		ApiRowVersionCheckRequestModel MapResponseToRequest(
			ApiRowVersionCheckResponseModel response);

		JsonPatchDocument<ApiRowVersionCheckRequestModel> CreatePatch(ApiRowVersionCheckRequestModel model);
	}
}

/*<Codenesium>
    <Hash>88b79e9f13c296913fde75baf07edeec</Hash>
</Codenesium>*/