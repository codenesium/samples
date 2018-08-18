using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiOctopusServerNodeModelMapper
	{
		ApiOctopusServerNodeResponseModel MapRequestToResponse(
			string id,
			ApiOctopusServerNodeRequestModel request);

		ApiOctopusServerNodeRequestModel MapResponseToRequest(
			ApiOctopusServerNodeResponseModel response);

		JsonPatchDocument<ApiOctopusServerNodeRequestModel> CreatePatch(ApiOctopusServerNodeRequestModel model);
	}
}

/*<Codenesium>
    <Hash>e52149f8029b4cc739477633772b67e6</Hash>
</Codenesium>*/