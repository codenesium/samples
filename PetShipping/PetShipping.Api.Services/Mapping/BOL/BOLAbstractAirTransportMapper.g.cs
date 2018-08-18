using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractAirTransportMapper
	{
		public virtual BOAirTransport MapModelToBO(
			int airlineId,
			ApiAirTransportRequestModel model
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

		public virtual ApiAirTransportResponseModel MapBOToModel(
			BOAirTransport boAirTransport)
		{
			var model = new ApiAirTransportResponseModel();

			model.SetProperties(boAirTransport.AirlineId, boAirTransport.FlightNumber, boAirTransport.HandlerId, boAirTransport.Id, boAirTransport.LandDate, boAirTransport.PipelineStepId, boAirTransport.TakeoffDate);

			return model;
		}

		public virtual List<ApiAirTransportResponseModel> MapBOToModel(
			List<BOAirTransport> items)
		{
			List<ApiAirTransportResponseModel> response = new List<ApiAirTransportResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>44aaec7785f82bd5cb57aedd767f588d</Hash>
</Codenesium>*/