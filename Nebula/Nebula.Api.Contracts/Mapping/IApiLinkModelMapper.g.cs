using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public partial interface IApiLinkModelMapper
	{
		ApiLinkResponseModel MapRequestToResponse(
			int id,
			ApiLinkRequestModel request);

		ApiLinkRequestModel MapResponseToRequest(
			ApiLinkResponseModel response);

		JsonPatchDocument<ApiLinkRequestModel> CreatePatch(ApiLinkRequestModel model);
	}
}

/*<Codenesium>
    <Hash>11bddd79cd66a6cf1e8d46ca5df684a1</Hash>
</Codenesium>*/