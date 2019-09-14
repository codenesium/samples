using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public class ApiHandlerPipelineStepModelMapper : IApiHandlerPipelineStepModelMapper
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
    <Hash>36c6d819cb191246862fa8b6a779965b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/