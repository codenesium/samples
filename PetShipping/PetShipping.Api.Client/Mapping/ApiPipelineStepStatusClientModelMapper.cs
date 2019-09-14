using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public class ApiPipelineStepStatusModelMapper : IApiPipelineStepStatusModelMapper
	{
		public virtual ApiPipelineStepStatusClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPipelineStepStatusClientRequestModel request)
		{
			var response = new ApiPipelineStepStatusClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiPipelineStepStatusClientRequestModel MapClientResponseToRequest(
			ApiPipelineStepStatusClientResponseModel response)
		{
			var request = new ApiPipelineStepStatusClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>eb22ab96b0fc8ad46a392c71a1a7bd8c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/