using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractAirTransportMapper
	{
		public virtual BOAirTransport MapModelToBO(
			int airlineId,
			ApiAirTransportServerRequestModel model
			)
		{
			BOAirTransport boAirTransport = new BOAirTransport();
			boAirTransport.SetProperties(
				airlineId,
				model.FlightNumber,
				model.HandlerId,
				model.Id,
				model.LandDate,
				model.PipelineStepId,
				model.TakeoffDate);
			return boAirTransport;
		}

		public virtual ApiAirTransportServerResponseModel MapBOToModel(
			BOAirTransport boAirTransport)
		{
			var model = new ApiAirTransportServerResponseModel();

			model.SetProperties(boAirTransport.AirlineId, boAirTransport.FlightNumber, boAirTransport.HandlerId, boAirTransport.Id, boAirTransport.LandDate, boAirTransport.PipelineStepId, boAirTransport.TakeoffDate);

			return model;
		}

		public virtual List<ApiAirTransportServerResponseModel> MapBOToModel(
			List<BOAirTransport> items)
		{
			List<ApiAirTransportServerResponseModel> response = new List<ApiAirTransportServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c523480226a2a4350f001c7b128de0c3</Hash>
</Codenesium>*/