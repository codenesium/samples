using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public abstract class AbstractApiPipelineStepStatusModelMapper
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
    <Hash>26218993434b990f81ef95c056275e7b</Hash>
</Codenesium>*/