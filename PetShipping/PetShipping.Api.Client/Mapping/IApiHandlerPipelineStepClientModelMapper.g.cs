using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public partial interface IApiHandlerPipelineStepModelMapper
	{
		ApiHandlerPipelineStepClientResponseModel MapClientRequestToResponse(
			int id,
			ApiHandlerPipelineStepClientRequestModel request);

		ApiHandlerPipelineStepClientRequestModel MapClientResponseToRequest(
			ApiHandlerPipelineStepClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>16aec8a78f06ecb7013265e615764ab3</Hash>
</Codenesium>*/