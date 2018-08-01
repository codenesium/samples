using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
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
    <Hash>4834a5c30a4b1b4ca10f32da6011f443</Hash>
</Codenesium>*/