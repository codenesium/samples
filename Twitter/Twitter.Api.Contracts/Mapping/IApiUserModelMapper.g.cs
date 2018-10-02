using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Contracts
{
	public partial interface IApiUserModelMapper
	{
		ApiUserResponseModel MapRequestToResponse(
			int userId,
			ApiUserRequestModel request);

		ApiUserRequestModel MapResponseToRequest(
			ApiUserResponseModel response);

		JsonPatchDocument<ApiUserRequestModel> CreatePatch(ApiUserRequestModel model);
	}
}

/*<Codenesium>
    <Hash>b17ebc0377cf3eb8a61c29bf503449ba</Hash>
</Codenesium>*/