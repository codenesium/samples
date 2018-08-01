using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiErrorLogModelMapper
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
    <Hash>0c975ec1a580545824674c02adf6e013</Hash>
</Codenesium>*/