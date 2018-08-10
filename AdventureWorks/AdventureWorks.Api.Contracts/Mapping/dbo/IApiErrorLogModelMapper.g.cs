using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiErrorLogModelMapper
	{
		ApiErrorLogResponseModel MapRequestToResponse(
			int errorLogID,
			ApiErrorLogRequestModel request);

		ApiErrorLogRequestModel MapResponseToRequest(
			ApiErrorLogResponseModel response);

		JsonPatchDocument<ApiErrorLogRequestModel> CreatePatch(ApiErrorLogRequestModel model);
	}
}

/*<Codenesium>
    <Hash>a8072ee136fbe4b94746b0e82360b754</Hash>
</Codenesium>*/