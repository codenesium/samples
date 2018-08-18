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
    <Hash>325f58f6a1944f04d5666b718c547c85</Hash>
</Codenesium>*/