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
    <Hash>c72d551797feb9175ab32a989bcae9f7</Hash>
</Codenesium>*/