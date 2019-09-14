using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public class ApiAirTransportModelMapper : IApiAirTransportModelMapper
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
    <Hash>9443531d39950741df427a090bbf1b11</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/