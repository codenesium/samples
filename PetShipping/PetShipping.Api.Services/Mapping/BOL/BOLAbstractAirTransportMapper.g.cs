using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractAirTransportMapper
	{
		public virtual BOAirTransport MapModelToBO(
			int airlineId,
			ApiAirTransportRequestModel model
			)
		{
			BOAirTransport BOAirTransport = new BOAirTransport();

			BOAirTransport.SetProperties(
				airlineId,
				model.FlightNumber,
				model.HandlerId,
				model.Id,
				model.LandDate,
				model.PipelineStepId,
				model.TakeoffDate);
			return BOAirTransport;
		}

		public virtual ApiAirTransportResponseModel MapBOToModel(
			BOAirTransport BOAirTransport)
		{
			if (BOAirTransport == null)
			{
				return null;
			}

			var model = new ApiAirTransportResponseModel();

			model.SetProperties(BOAirTransport.AirlineId, BOAirTransport.FlightNumber, BOAirTransport.HandlerId, BOAirTransport.Id, BOAirTransport.LandDate, BOAirTransport.PipelineStepId, BOAirTransport.TakeoffDate);

			return model;
		}

		public virtual List<ApiAirTransportResponseModel> MapBOToModel(
			List<BOAirTransport> BOs)
		{
			List<ApiAirTransportResponseModel> response = new List<ApiAirTransportResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4e0ab822966be0027f38211586111cc7</Hash>
</Codenesium>*/