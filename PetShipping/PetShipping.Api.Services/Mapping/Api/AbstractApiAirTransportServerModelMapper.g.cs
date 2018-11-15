using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiAirTransportServerModelMapper
	{
		public virtual ApiAirTransportServerResponseModel MapServerRequestToResponse(
			int airlineId,
			ApiAirTransportServerRequestModel request)
		{
			var response = new ApiAirTransportServerResponseModel();
			response.SetProperties(airlineId,
			                       request.FlightNumber,
			                       request.HandlerId,
			                       request.Id,
			                       request.LandDate,
			                       request.PipelineStepId,
			                       request.TakeoffDate);
			return response;
		}

		public virtual ApiAirTransportServerRequestModel MapServerResponseToRequest(
			ApiAirTransportServerResponseModel response)
		{
			var request = new ApiAirTransportServerRequestModel();
			request.SetProperties(
				response.FlightNumber,
				response.HandlerId,
				response.Id,
				response.LandDate,
				response.PipelineStepId,
				response.TakeoffDate);
			return request;
		}

		public virtual ApiAirTransportClientRequestModel MapServerResponseToClientRequest(
			ApiAirTransportServerResponseModel response)
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

		public JsonPatchDocument<ApiAirTransportServerRequestModel> CreatePatch(ApiAirTransportServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiAirTransportServerRequestModel>();
			patch.Replace(x => x.FlightNumber, model.FlightNumber);
			patch.Replace(x => x.HandlerId, model.HandlerId);
			patch.Replace(x => x.Id, model.Id);
			patch.Replace(x => x.LandDate, model.LandDate);
			patch.Replace(x => x.PipelineStepId, model.PipelineStepId);
			patch.Replace(x => x.TakeoffDate, model.TakeoffDate);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>7ce4331c5816015cd698d20380ed5b93</Hash>
</Codenesium>*/