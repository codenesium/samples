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
    <Hash>826efcacaae2300670909137f51ca0f8</Hash>
</Codenesium>*/