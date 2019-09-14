using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public class ApiPipelineStepDestinationModelMapper : IApiPipelineStepDestinationModelMapper
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
    <Hash>f1e378a8de90dd0a3bc02c97cfc0c093</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/