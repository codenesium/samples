using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiPersonModelMapper
	{
		ApiPersonResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiPersonRequestModel request);

		ApiPersonRequestModel MapResponseToRequest(
			ApiPersonResponseModel response);

		JsonPatchDocument<ApiPersonRequestModel> CreatePatch(ApiPersonRequestModel model);
	}
}

/*<Codenesium>
    <Hash>39e9fc14f22f31e57f65162acac3d26d</Hash>
</Codenesium>*/