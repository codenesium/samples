using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public partial interface IApiClaspModelMapper
	{
		ApiClaspResponseModel MapRequestToResponse(
			int id,
			ApiClaspRequestModel request);

		ApiClaspRequestModel MapResponseToRequest(
			ApiClaspResponseModel response);

		JsonPatchDocument<ApiClaspRequestModel> CreatePatch(ApiClaspRequestModel model);
	}
}

/*<Codenesium>
    <Hash>cfb9062095d150f99f4c9166e568432f</Hash>
</Codenesium>*/