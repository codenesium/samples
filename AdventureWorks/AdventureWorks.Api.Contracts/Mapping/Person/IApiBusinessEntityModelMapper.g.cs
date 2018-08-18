using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiBusinessEntityModelMapper
	{
		ApiBusinessEntityResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiBusinessEntityRequestModel request);

		ApiBusinessEntityRequestModel MapResponseToRequest(
			ApiBusinessEntityResponseModel response);

		JsonPatchDocument<ApiBusinessEntityRequestModel> CreatePatch(ApiBusinessEntityRequestModel model);
	}
}

/*<Codenesium>
    <Hash>d4f036ea360118873091418d6643b599</Hash>
</Codenesium>*/