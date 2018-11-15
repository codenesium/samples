using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public abstract class AbstractApiHandlerPipelineStepModelMapper
	{
		public virtual ApiHandlerPipelineStepClientResponseModel MapClientRequestToResponse(
			int id,
			ApiHandlerPipelineStepClientRequestModel request)
		{
			var response = new ApiHandlerPipelineStepClientResponseModel();
			response.SetProperties(id,
			                       request.HandlerId,
			                       request.PipelineStepId);
			return response;
		}

		public virtual ApiHandlerPipelineStepClientRequestModel MapClientResponseToRequest(
			ApiHandlerPipelineStepClientResponseModel response)
		{
			var request = new ApiHandlerPipelineStepClientRequestModel();
			request.SetProperties(
				response.HandlerId,
				response.PipelineStepId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>ff4e8f66a1303aafe4e17aaa5289c938</Hash>
</Codenesium>*/