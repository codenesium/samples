using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public abstract class AbstractApiOtherTransportModelMapper
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
    <Hash>b2283ee28fa7ad271234f19f6c575c73</Hash>
</Codenesium>*/