using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Contracts
{
	public partial interface IApiMessageModelMapper
	{
		ApiMessageResponseModel MapRequestToResponse(
			int messageId,
			ApiMessageRequestModel request);

		ApiMessageRequestModel MapResponseToRequest(
			ApiMessageResponseModel response);

		JsonPatchDocument<ApiMessageRequestModel> CreatePatch(ApiMessageRequestModel model);
	}
}

/*<Codenesium>
    <Hash>01c7698dd04c21e26ecfe2cdeee5e9c1</Hash>
</Codenesium>*/