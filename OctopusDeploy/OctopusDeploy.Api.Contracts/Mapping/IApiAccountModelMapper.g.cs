using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiAccountModelMapper
	{
		ApiAccountResponseModel MapRequestToResponse(
			string id,
			ApiAccountRequestModel request);

		ApiAccountRequestModel MapResponseToRequest(
			ApiAccountResponseModel response);

		JsonPatchDocument<ApiAccountRequestModel> CreatePatch(ApiAccountRequestModel model);
	}
}

/*<Codenesium>
    <Hash>ae9ca4cef33ea0add717a8568f5c1685</Hash>
</Codenesium>*/