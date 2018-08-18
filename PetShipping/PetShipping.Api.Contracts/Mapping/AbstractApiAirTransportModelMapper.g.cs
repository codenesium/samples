using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public abstract class AbstractApiAirTransportModelMapper
	{
		public virtual ApiAirTransportResponseModel MapRequestToResponse(
			int airlineId,
			ApiAirTransportRequestModel request)
		{
			var response = new ApiAirTransportResponseModel();
			response.SetProperties(airlineId,
			                       request.FlightNumber,
			                       request.HandlerId,
			                       request.Id,
			                       request.LandDate,
			                       request.PipelineStepId,
			                       request.TakeoffDate);
			return response;
		}

		public virtual ApiAirTransportRequestModel MapResponseToRequest(
			ApiAirTransportResponseModel response)
		{
			var request = new ApiAirTransportRequestModel();
			request.SetProperties(
				response.FlightNumber,
				response.HandlerId,
				response.Id,
				response.LandDate,
				response.PipelineStepId,
				response.TakeoffDate);
			return request;
		}

		public JsonPatchDocument<ApiAirTransportRequestModel> CreatePatch(ApiAirTransportRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiAirTransportRequestModel>();
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
    <Hash>13eabefedd9204ee2884a21b3e421f28</Hash>
</Codenesium>*/