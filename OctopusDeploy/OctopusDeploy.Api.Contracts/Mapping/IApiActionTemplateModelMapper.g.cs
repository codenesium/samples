using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiActionTemplateModelMapper
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
    <Hash>dbbe2be1168ae56f84bf08715dbad4ad</Hash>
</Codenesium>*/