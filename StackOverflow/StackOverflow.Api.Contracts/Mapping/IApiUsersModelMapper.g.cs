using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public interface IApiUsersModelMapper
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
    <Hash>fe7d4129f74cbdc74da97668eae289d5</Hash>
</Codenesium>*/