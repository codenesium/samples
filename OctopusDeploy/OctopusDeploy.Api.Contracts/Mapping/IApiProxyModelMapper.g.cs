using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiProxyModelMapper
	{
		ApiProxyResponseModel MapRequestToResponse(
			string id,
			ApiProxyRequestModel request);

		ApiProxyRequestModel MapResponseToRequest(
			ApiProxyResponseModel response);

		JsonPatchDocument<ApiProxyRequestModel> CreatePatch(ApiProxyRequestModel model);
	}
}

/*<Codenesium>
    <Hash>deb60d5923260fe3ccca80ecd380fe8e</Hash>
</Codenesium>*/