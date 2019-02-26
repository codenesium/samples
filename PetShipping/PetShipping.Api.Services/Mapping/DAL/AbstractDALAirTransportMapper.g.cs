using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractDALAirTransportMapper
	{
		public virtual AirTransport MapModelToEntity(
			int id,
			ApiAirTransportServerRequestModel model
			)
		{
			AirTransport item = new AirTransport();
			item.SetProperties(
				id,
				model.AirlineId,
				model.FlightNumber,
				model.HandlerId,
				model.LandDate,
				model.PipelineStepId,
				model.TakeoffDate);
			return item;
		}

		public virtual ApiAirTransportServerResponseModel MapEntityToModel(
			AirTransport item)
		{
			var model = new ApiAirTransportServerResponseModel();

			model.SetProperties(item.Id,
			                    item.AirlineId,
			                    item.FlightNumber,
			                    item.HandlerId,
			                    item.LandDate,
			                    item.PipelineStepId,
			                    item.TakeoffDate);
			if (item.HandlerIdNavigation != null)
			{
				var handlerIdModel = new ApiHandlerServerResponseModel();
				handlerIdModel.SetProperties(
					item.HandlerIdNavigation.Id,
					item.HandlerIdNavigation.CountryId,
					item.HandlerIdNavigation.Email,
					item.HandlerIdNavigation.FirstName,
					item.HandlerIdNavigation.LastName,
					item.HandlerIdNavigation.Phone);

				model.SetHandlerIdNavigation(handlerIdModel);
			}

			return model;
		}

		public virtual List<ApiAirTransportServerResponseModel> MapEntityToModel(
			List<AirTransport> items)
		{
			List<ApiAirTransportServerResponseModel> response = new List<ApiAirTransportServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4a6daf4d2d65354b7f5e1436206e442a</Hash>
</Codenesium>*/