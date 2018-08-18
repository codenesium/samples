using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public partial interface IApiPostHistoryTypesModelMapper
	{
		ApiPostHistoryTypesResponseModel MapRequestToResponse(
			int id,
			ApiPostHistoryTypesRequestModel request);

		ApiPostHistoryTypesRequestModel MapResponseToRequest(
			ApiPostHistoryTypesResponseModel response);

		JsonPatchDocument<ApiPostHistoryTypesRequestModel> CreatePatch(ApiPostHistoryTypesRequestModel model);
	}
}

/*<Codenesium>
    <Hash>aade08796c1782a4af7e0e18f84aa7ad</Hash>
</Codenesium>*/