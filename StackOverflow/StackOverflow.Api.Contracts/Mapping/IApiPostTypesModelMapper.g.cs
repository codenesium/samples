using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public partial interface IApiPostTypesModelMapper
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
    <Hash>94df0dfb79cfee939e0fb38843d9c467</Hash>
</Codenesium>*/