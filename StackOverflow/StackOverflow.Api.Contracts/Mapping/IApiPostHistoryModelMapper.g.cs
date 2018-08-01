using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public interface IApiPostHistoryModelMapper
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
    <Hash>ebd9e5c371c24b00513b6894f09acb65</Hash>
</Codenesium>*/