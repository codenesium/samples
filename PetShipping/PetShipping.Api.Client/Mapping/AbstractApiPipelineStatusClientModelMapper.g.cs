using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public abstract class AbstractApiPipelineStatusModelMapper
	{
		public virtual ApiPipelineStatusClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPipelineStatusClientRequestModel request)
		{
			var response = new ApiPipelineStatusClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiPipelineStatusClientRequestModel MapClientResponseToRequest(
			ApiPipelineStatusClientResponseModel response)
		{
			var request = new ApiPipelineStatusClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>dc3d5409e66e9fec3d867945b805da0c</Hash>
</Codenesium>*/