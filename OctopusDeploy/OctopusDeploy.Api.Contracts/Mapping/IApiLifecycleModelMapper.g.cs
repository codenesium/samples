using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiLifecycleModelMapper
	{
		ApiLifecycleResponseModel MapRequestToResponse(
			string id,
			ApiLifecycleRequestModel request);

		ApiLifecycleRequestModel MapResponseToRequest(
			ApiLifecycleResponseModel response);

		JsonPatchDocument<ApiLifecycleRequestModel> CreatePatch(ApiLifecycleRequestModel model);
	}
}

/*<Codenesium>
    <Hash>112d6e51100bdf22a65dc80004276cfa</Hash>
</Codenesium>*/