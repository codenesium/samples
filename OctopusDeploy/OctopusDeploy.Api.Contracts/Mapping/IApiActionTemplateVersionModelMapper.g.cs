using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiActionTemplateVersionModelMapper
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
    <Hash>9d424411d88bfc0a9cadda697535a8c1</Hash>
</Codenesium>*/