using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiCommunityActionTemplateModelMapper
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
    <Hash>8b3c253f987e1e2533a5763dd3f15fc5</Hash>
</Codenesium>*/