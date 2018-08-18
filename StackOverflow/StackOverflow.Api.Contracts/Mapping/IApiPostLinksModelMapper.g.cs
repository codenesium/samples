using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public partial interface IApiPostLinksModelMapper
	{
		ApiPostLinksResponseModel MapRequestToResponse(
			int id,
			ApiPostLinksRequestModel request);

		ApiPostLinksRequestModel MapResponseToRequest(
			ApiPostLinksResponseModel response);

		JsonPatchDocument<ApiPostLinksRequestModel> CreatePatch(ApiPostLinksRequestModel model);
	}
}

/*<Codenesium>
    <Hash>672b217538da8c62f54cb857fe9267bc</Hash>
</Codenesium>*/