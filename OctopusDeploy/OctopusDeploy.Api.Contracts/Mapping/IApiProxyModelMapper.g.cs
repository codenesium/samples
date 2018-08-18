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
    <Hash>a5346a5cdbf068831c776cb567311c61</Hash>
</Codenesium>*/