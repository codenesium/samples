using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public partial interface IApiPipelineStepStatuModelMapper
	{
		ApiPipelineStepStatuResponseModel MapRequestToResponse(
			int id,
			ApiPipelineStepStatuRequestModel request);

		ApiPipelineStepStatuRequestModel MapResponseToRequest(
			ApiPipelineStepStatuResponseModel response);

		JsonPatchDocument<ApiPipelineStepStatuRequestModel> CreatePatch(ApiPipelineStepStatuRequestModel model);
	}
}

/*<Codenesium>
    <Hash>a659faa2e12cbaa8fa8a9a7bdae65f06</Hash>
</Codenesium>*/