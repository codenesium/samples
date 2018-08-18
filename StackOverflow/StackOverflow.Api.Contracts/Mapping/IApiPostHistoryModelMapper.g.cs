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
    <Hash>35fc42677a6a265a9be938d370af6465</Hash>
</Codenesium>*/