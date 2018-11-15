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
    <Hash>9733bee674e17f7f582ce69d7ee305ec</Hash>
</Codenesium>*/