using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public interface IApiPipelineStepStatusModelMapper
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
    <Hash>c46455f3a438d42853fafc3317bface2</Hash>
</Codenesium>*/