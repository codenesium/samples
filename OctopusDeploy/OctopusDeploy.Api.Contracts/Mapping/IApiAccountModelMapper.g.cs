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
    <Hash>ca08bbd55d77bd6b2f1915eb2fff5daf</Hash>
</Codenesium>*/