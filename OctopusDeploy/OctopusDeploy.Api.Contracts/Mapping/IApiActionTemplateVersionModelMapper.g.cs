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
    <Hash>06233f0f1893e588c345592fbd0cdddb</Hash>
</Codenesium>*/