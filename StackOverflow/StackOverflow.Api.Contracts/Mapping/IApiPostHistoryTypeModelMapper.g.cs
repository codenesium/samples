using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public partial interface IApiPostHistoryTypeModelMapper
	{
		ApiPostHistoryTypeResponseModel MapRequestToResponse(
			int id,
			ApiPostHistoryTypeRequestModel request);

		ApiPostHistoryTypeRequestModel MapResponseToRequest(
			ApiPostHistoryTypeResponseModel response);

		JsonPatchDocument<ApiPostHistoryTypeRequestModel> CreatePatch(ApiPostHistoryTypeRequestModel model);
	}
}

/*<Codenesium>
    <Hash>d5413cb18ddc132d43b945bc9bea562e</Hash>
</Codenesium>*/