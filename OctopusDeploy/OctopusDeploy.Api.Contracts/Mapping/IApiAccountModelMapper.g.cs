using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiAccountModelMapper
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
    <Hash>989ae3bb6aa1cc609232f469f4ea323c</Hash>
</Codenesium>*/