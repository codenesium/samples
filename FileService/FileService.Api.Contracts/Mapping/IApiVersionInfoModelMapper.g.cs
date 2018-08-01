using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Contracts
{
	public interface IApiVersionInfoModelMapper
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
    <Hash>86c9cc8be05d6dbbfedd5cb2e027075f</Hash>
</Codenesium>*/