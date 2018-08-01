using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiBusinessEntityModelMapper
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
    <Hash>ceb0ea813a4b29a349c342dcf86001ed</Hash>
</Codenesium>*/