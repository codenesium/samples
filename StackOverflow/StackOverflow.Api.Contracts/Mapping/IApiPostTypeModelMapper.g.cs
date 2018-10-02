using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public partial interface IApiPostTypeModelMapper
	{
		ApiPostTypeResponseModel MapRequestToResponse(
			int id,
			ApiPostTypeRequestModel request);

		ApiPostTypeRequestModel MapResponseToRequest(
			ApiPostTypeResponseModel response);

		JsonPatchDocument<ApiPostTypeRequestModel> CreatePatch(ApiPostTypeRequestModel model);
	}
}

/*<Codenesium>
    <Hash>6a7d404f6972c4e8c32d9b64aa8e7a88</Hash>
</Codenesium>*/