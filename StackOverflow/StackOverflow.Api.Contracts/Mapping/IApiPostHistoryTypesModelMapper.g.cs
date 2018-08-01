using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public interface IApiPostHistoryTypesModelMapper
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
    <Hash>f4ba6ddf24f7e9332fbce9c828044554</Hash>
</Codenesium>*/