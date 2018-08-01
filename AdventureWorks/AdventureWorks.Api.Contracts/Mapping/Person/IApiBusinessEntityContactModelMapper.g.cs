using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiBusinessEntityContactModelMapper
	{
		ApiBusinessEntityContactResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiBusinessEntityContactRequestModel request);

		ApiBusinessEntityContactRequestModel MapResponseToRequest(
			ApiBusinessEntityContactResponseModel response);

		JsonPatchDocument<ApiBusinessEntityContactRequestModel> CreatePatch(ApiBusinessEntityContactRequestModel model);
	}
}

/*<Codenesium>
    <Hash>196b02c478c828d2278f370cfacdd3fb</Hash>
</Codenesium>*/