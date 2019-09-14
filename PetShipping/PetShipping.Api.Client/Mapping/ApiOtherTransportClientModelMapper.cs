using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public class ApiOtherTransportModelMapper : IApiOtherTransportModelMapper
	{
		public virtual ApiOtherTransportClientResponseModel MapClientRequestToResponse(
			int id,
			ApiOtherTransportClientRequestModel request)
		{
			var response = new ApiOtherTransportClientResponseModel();
			response.SetProperties(id,
			                       request.HandlerId,
			                       request.PipelineStepId);
			return response;
		}

		public virtual ApiOtherTransportClientRequestModel MapClientResponseToRequest(
			ApiOtherTransportClientResponseModel response)
		{
			var request = new ApiOtherTransportClientRequestModel();
			request.SetProperties(
				response.HandlerId,
				response.PipelineStepId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>e709d4e13d5f20e0450455061ebc6b20</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/