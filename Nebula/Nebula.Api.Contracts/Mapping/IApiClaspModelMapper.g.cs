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
    <Hash>c5d7e20bbd36aa4f4e2faa690672a472</Hash>
</Codenesium>*/