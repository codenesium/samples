using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public abstract class AbstractApiPipelineStepModelMapper
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
    <Hash>e774c466d4978a6e013a8bfdd8e276c5</Hash>
</Codenesium>*/