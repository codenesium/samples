using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiActionTemplateVersionModelMapper
	{
		ApiActionTemplateVersionResponseModel MapRequestToResponse(
			string id,
			ApiActionTemplateVersionRequestModel request);

		ApiActionTemplateVersionRequestModel MapResponseToRequest(
			ApiActionTemplateVersionResponseModel response);

		JsonPatchDocument<ApiActionTemplateVersionRequestModel> CreatePatch(ApiActionTemplateVersionRequestModel model);
	}
}

/*<Codenesium>
    <Hash>4126bae7c8b2e66fea34bbfba9c13081</Hash>
</Codenesium>*/