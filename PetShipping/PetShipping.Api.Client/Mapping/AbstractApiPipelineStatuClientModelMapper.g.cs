using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public abstract class AbstractApiPipelineStatuModelMapper
	{
		public virtual ApiPipelineStatuClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPipelineStatuClientRequestModel request)
		{
			var response = new ApiPipelineStatuClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiPipelineStatuClientRequestModel MapClientResponseToRequest(
			ApiPipelineStatuClientResponseModel response)
		{
			var request = new ApiPipelineStatuClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>782240c98b6a65ef58a592d9963ad4d0</Hash>
</Codenesium>*/