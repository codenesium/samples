using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public abstract class AbstractApiAirTransportModelMapper
	{
		public virtual ApiAirTransportClientResponseModel MapClientRequestToResponse(
			int id,
			ApiAirTransportClientRequestModel request)
		{
			var response = new ApiAirTransportClientResponseModel();
			response.SetProperties(id,
			                       request.AirlineId,
			                       request.FlightNumber,
			                       request.HandlerId,
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
				response.AirlineId,
				response.FlightNumber,
				response.HandlerId,
				response.LandDate,
				response.PipelineStepId,
				response.TakeoffDate);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>52e81149f3648428d02bd9f99cdfb6bc</Hash>
</Codenesium>*/