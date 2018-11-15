using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public abstract class AbstractApiAirTransportModelMapper
	{
		public virtual ApiAirTransportClientResponseModel MapClientRequestToResponse(
			int airlineId,
			ApiAirTransportClientRequestModel request)
		{
			var response = new ApiAirTransportClientResponseModel();
			response.SetProperties(airlineId,
			                       request.FlightNumber,
			                       request.HandlerId,
			                       request.Id,
			                       request.LandDate,
			                       request.PipelineStepId,
			                       request.TakeoffDate);
			return response;
		}

		public virtual ApiAirTransportClientRequestModel MapClientResponseToRequest(
			ApiAirTransportClientResponseModel response)
		{
			var request = new ApiAirTransportClientRequestModel();
			request.SetProperties(
				response.FlightNumber,
				response.HandlerId,
				response.Id,
				response.LandDate,
				response.PipelineStepId,
				response.TakeoffDate);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>d331a4f1c2d4a802abd59b05856c4427</Hash>
</Codenesium>*/