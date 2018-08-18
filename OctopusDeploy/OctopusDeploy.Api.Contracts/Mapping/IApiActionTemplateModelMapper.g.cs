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
    <Hash>640a989965370c37ced12507c22b9b4c</Hash>
</Codenesium>*/