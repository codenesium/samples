using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public interface IApiPostTypesModelMapper
	{
		ApiPostTypesResponseModel MapRequestToResponse(
			int id,
			ApiPostTypesRequestModel request);

		ApiPostTypesRequestModel MapResponseToRequest(
			ApiPostTypesResponseModel response);

		JsonPatchDocument<ApiPostTypesRequestModel> CreatePatch(ApiPostTypesRequestModel model);
	}
}

/*<Codenesium>
    <Hash>8cfaf48a7693911d6f5cb4b5e9358fc4</Hash>
</Codenesium>*/