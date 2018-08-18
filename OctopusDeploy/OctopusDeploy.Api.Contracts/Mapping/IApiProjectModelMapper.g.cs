using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiProjectModelMapper
	{
		ApiProjectResponseModel MapRequestToResponse(
			string id,
			ApiProjectRequestModel request);

		ApiProjectRequestModel MapResponseToRequest(
			ApiProjectResponseModel response);

		JsonPatchDocument<ApiProjectRequestModel> CreatePatch(ApiProjectRequestModel model);
	}
}

/*<Codenesium>
    <Hash>804a6437f40015da0c2ca46e12a44e9d</Hash>
</Codenesium>*/