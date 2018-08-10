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
    <Hash>e8dec3924666b5dfa53495e23dfc9cc6</Hash>
</Codenesium>*/