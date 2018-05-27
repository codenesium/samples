using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOLAirTransportMapper
	{
		public virtual DTOAirTransport MapModelToDTO(
			int airlineId,
			ApiAirTransportRequestModel model
			)
		{
			DTOAirTransport dtoAirTransport = new DTOAirTransport();

			dtoAirTransport.SetProperties(
				airlineId,
				model.FlightNumber,
				model.HandlerId,
				model.Id,
				model.LandDate,
				model.PipelineStepId,
				model.TakeoffDate);
			return dtoAirTransport;
		}

		public virtual ApiAirTransportResponseModel MapDTOToModel(
			DTOAirTransport dtoAirTransport)
		{
			if (dtoAirTransport == null)
			{
				return null;
			}

			var model = new ApiAirTransportResponseModel();

			model.SetProperties(dtoAirTransport.AirlineId, dtoAirTransport.FlightNumber, dtoAirTransport.HandlerId, dtoAirTransport.Id, dtoAirTransport.LandDate, dtoAirTransport.PipelineStepId, dtoAirTransport.TakeoffDate);

			return model;
		}

		public virtual List<ApiAirTransportResponseModel> MapDTOToModel(
			List<DTOAirTransport> dtos)
		{
			List<ApiAirTransportResponseModel> response = new List<ApiAirTransportResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6a629f3b1b97e7d6b2da5872955d2be9</Hash>
</Codenesium>*/