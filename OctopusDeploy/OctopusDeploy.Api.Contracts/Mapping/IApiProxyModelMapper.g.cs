using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiProxyModelMapper
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
    <Hash>0b50d66634c9a51294cc85787f88b5da</Hash>
</Codenesium>*/