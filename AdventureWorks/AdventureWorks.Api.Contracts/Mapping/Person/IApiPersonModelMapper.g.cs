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
    <Hash>3ab66b07d35be49bb9dbcd9ca187c79c</Hash>
</Codenesium>*/