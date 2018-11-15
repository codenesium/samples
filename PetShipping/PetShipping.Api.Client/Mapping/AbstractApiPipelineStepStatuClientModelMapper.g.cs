using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public abstract class AbstractApiPipelineStepStatuModelMapper
	{
		public virtual ApiPipelineStepStatuClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPipelineStepStatuClientRequestModel request)
		{
			var response = new ApiPipelineStepStatuClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiPipelineStepStatuClientRequestModel MapClientResponseToRequest(
			ApiPipelineStepStatuClientResponseModel response)
		{
			var request = new ApiPipelineStepStatuClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>693161787f9a83a23fe84966cd3ace09</Hash>
</Codenesium>*/