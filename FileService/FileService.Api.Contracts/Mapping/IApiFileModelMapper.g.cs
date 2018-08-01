using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Contracts
{
	public interface IApiFileModelMapper
	{
		ApiFileResponseModel MapRequestToResponse(
			int id,
			ApiFileRequestModel request);

		ApiFileRequestModel MapResponseToRequest(
			ApiFileResponseModel response);

		JsonPatchDocument<ApiFileRequestModel> CreatePatch(ApiFileRequestModel model);
	}
}

/*<Codenesium>
    <Hash>2c9322a774917db092d5e198ad9db11b</Hash>
</Codenesium>*/