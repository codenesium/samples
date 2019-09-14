using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public class ApiPipelineStatusModelMapper : IApiPipelineStatusModelMapper
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
    <Hash>36a740d7df01da978a2cf3a16e60cff1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/