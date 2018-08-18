using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Contracts
{
	public partial interface IApiVersionInfoModelMapper
	{
		ApiVersionInfoResponseModel MapRequestToResponse(
			long version,
			ApiVersionInfoRequestModel request);

		ApiVersionInfoRequestModel MapResponseToRequest(
			ApiVersionInfoResponseModel response);

		JsonPatchDocument<ApiVersionInfoRequestModel> CreatePatch(ApiVersionInfoRequestModel model);
	}
}

/*<Codenesium>
    <Hash>435d8486864d3f9a8bf8ce22d427c85c</Hash>
</Codenesium>*/