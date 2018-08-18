using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public partial interface IApiUsersModelMapper
	{
		ApiUsersResponseModel MapRequestToResponse(
			int id,
			ApiUsersRequestModel request);

		ApiUsersRequestModel MapResponseToRequest(
			ApiUsersResponseModel response);

		JsonPatchDocument<ApiUsersRequestModel> CreatePatch(ApiUsersRequestModel model);
	}
}

/*<Codenesium>
    <Hash>2494b7bd38a19f63db57351c8ff15ecc</Hash>
</Codenesium>*/