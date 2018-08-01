using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public interface IApiClaspModelMapper
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
    <Hash>07a538900f7350bdfa81798e546a9588</Hash>
</Codenesium>*/