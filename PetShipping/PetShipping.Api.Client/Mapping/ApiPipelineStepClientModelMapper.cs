using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public class ApiPipelineStepModelMapper : IApiPipelineStepModelMapper
	{
		public virtual ApiPipelineStepClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPipelineStepClientRequestModel request)
		{
			var response = new ApiPipelineStepClientResponseModel();
			response.SetProperties(id,
			                       request.Name,
			                       request.PipelineStepStatusId,
			                       request.ShipperId);
			return response;
		}

		public virtual ApiPipelineStepClientRequestModel MapClientResponseToRequest(
			ApiPipelineStepClientResponseModel response)
		{
			var request = new ApiPipelineStepClientRequestModel();
			request.SetProperties(
				response.Name,
				response.PipelineStepStatusId,
				response.ShipperId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>a4543b50e319ccf0db67b9b78980888f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/