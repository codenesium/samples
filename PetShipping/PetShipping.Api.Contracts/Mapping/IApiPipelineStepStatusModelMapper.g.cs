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
    <Hash>a651975fe58c0b875a40392a8ba06090</Hash>
</Codenesium>*/