using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
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
    <Hash>68033dd4a51f81ca6a017e57cfe982fb</Hash>
</Codenesium>*/