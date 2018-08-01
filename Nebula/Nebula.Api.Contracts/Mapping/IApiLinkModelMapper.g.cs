using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public interface IApiLinkModelMapper
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
    <Hash>dbb7480d670c605953c9a41190c9e13e</Hash>
</Codenesium>*/