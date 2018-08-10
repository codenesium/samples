using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public partial interface IApiPostHistoryModelMapper
	{
		ApiPostHistoryResponseModel MapRequestToResponse(
			int id,
			ApiPostHistoryRequestModel request);

		ApiPostHistoryRequestModel MapResponseToRequest(
			ApiPostHistoryResponseModel response);

		JsonPatchDocument<ApiPostHistoryRequestModel> CreatePatch(ApiPostHistoryRequestModel model);
	}
}

/*<Codenesium>
    <Hash>89114a1a19242fe2d36a855d78e14bd0</Hash>
</Codenesium>*/