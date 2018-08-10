using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiActionTemplateModelMapper
	{
		ApiActionTemplateResponseModel MapRequestToResponse(
			string id,
			ApiActionTemplateRequestModel request);

		ApiActionTemplateRequestModel MapResponseToRequest(
			ApiActionTemplateResponseModel response);

		JsonPatchDocument<ApiActionTemplateRequestModel> CreatePatch(ApiActionTemplateRequestModel model);
	}
}

/*<Codenesium>
    <Hash>1b5fddca88f9d56f21394baa502bbc19</Hash>
</Codenesium>*/