using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiCommunityActionTemplateModelMapper
	{
		ApiCommunityActionTemplateResponseModel MapRequestToResponse(
			string id,
			ApiCommunityActionTemplateRequestModel request);

		ApiCommunityActionTemplateRequestModel MapResponseToRequest(
			ApiCommunityActionTemplateResponseModel response);

		JsonPatchDocument<ApiCommunityActionTemplateRequestModel> CreatePatch(ApiCommunityActionTemplateRequestModel model);
	}
}

/*<Codenesium>
    <Hash>d8f5be048ebf577c438c3ba9039d7f14</Hash>
</Codenesium>*/