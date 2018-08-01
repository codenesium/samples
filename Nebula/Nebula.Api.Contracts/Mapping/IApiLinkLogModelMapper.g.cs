using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public interface IApiLinkLogModelMapper
	{
		ApiLinkLogResponseModel MapRequestToResponse(
			int id,
			ApiLinkLogRequestModel request);

		ApiLinkLogRequestModel MapResponseToRequest(
			ApiLinkLogResponseModel response);

		JsonPatchDocument<ApiLinkLogRequestModel> CreatePatch(ApiLinkLogRequestModel model);
	}
}

/*<Codenesium>
    <Hash>18d1cf03f9e1bd8da17d014baa9d8e32</Hash>
</Codenesium>*/