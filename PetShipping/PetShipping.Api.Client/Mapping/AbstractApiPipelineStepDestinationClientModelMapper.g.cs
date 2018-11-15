using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public abstract class AbstractApiPipelineStepDestinationModelMapper
	{
		public virtual ApiPipelineStepDestinationClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPipelineStepDestinationClientRequestModel request)
		{
			var response = new ApiPipelineStepDestinationClientResponseModel();
			response.SetProperties(id,
			                       request.DestinationId,
			                       request.PipelineStepId);
			return response;
		}

		public virtual ApiPipelineStepDestinationClientRequestModel MapClientResponseToRequest(
			ApiPipelineStepDestinationClientResponseModel response)
		{
			var request = new ApiPipelineStepDestinationClientRequestModel();
			request.SetProperties(
				response.DestinationId,
				response.PipelineStepId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>312aa90aa340b3168754904d6532bb1e</Hash>
</Codenesium>*/