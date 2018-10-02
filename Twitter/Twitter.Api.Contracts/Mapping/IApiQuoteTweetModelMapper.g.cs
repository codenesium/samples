using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Contracts
{
	public partial interface IApiQuoteTweetModelMapper
	{
		ApiQuoteTweetResponseModel MapRequestToResponse(
			int quoteTweetId,
			ApiQuoteTweetRequestModel request);

		ApiQuoteTweetRequestModel MapResponseToRequest(
			ApiQuoteTweetResponseModel response);

		JsonPatchDocument<ApiQuoteTweetRequestModel> CreatePatch(ApiQuoteTweetRequestModel model);
	}
}

/*<Codenesium>
    <Hash>3e64428ebdafda41ddaa219b46d042f3</Hash>
</Codenesium>*/