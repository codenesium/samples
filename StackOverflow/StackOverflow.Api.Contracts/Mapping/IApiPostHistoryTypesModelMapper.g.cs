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
    <Hash>1569b88e4d3ded98bdfcf392038cd503</Hash>
</Codenesium>*/