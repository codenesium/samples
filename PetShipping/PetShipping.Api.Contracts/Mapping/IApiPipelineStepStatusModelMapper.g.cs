using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public partial interface IApiPipelineStepStatusModelMapper
	{
		ApiPipelineStepStatusResponseModel MapRequestToResponse(
			int id,
			ApiPipelineStepStatusRequestModel request);

		ApiPipelineStepStatusRequestModel MapResponseToRequest(
			ApiPipelineStepStatusResponseModel response);

		JsonPatchDocument<ApiPipelineStepStatusRequestModel> CreatePatch(ApiPipelineStepStatusRequestModel model);
	}
}

/*<Codenesium>
    <Hash>d34fbbc22b4b7d99b8f9f5ba7795431e</Hash>
</Codenesium>*/