using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractDALAirTransportMapper
	{
		public virtual AirTransport MapModelToEntity(
			int airlineId,
			ApiAirTransportServerRequestModel model
			)
		{
			AirTransport item = new AirTransport();
			item.SetProperties(
				airlineId,
				model.FlightNumber,
				model.HandlerId,
				model.Id,
				model.LandDate,
				model.PipelineStepId,
				model.TakeoffDate);
			return item;
		}

		public virtual ApiAirTransportServerResponseModel MapEntityToModel(
			AirTransport item)
		{
			var model = new ApiAirTransportServerResponseModel();

			model.SetProperties(item.AirlineId,
			                    item.FlightNumber,
			                    item.HandlerId,
			                    item.Id,
			                    item.LandDate,
			                    item.PipelineStepId,
			                    item.TakeoffDate);
			if (item.HandlerIdNavigation != null)
			{
				var handlerIdModel = new ApiHandlerServerResponseModel();
				handlerIdModel.SetProperties(
					item.Id,
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
    <Hash>e586f5fde912c7fd29f8e197e73b96c3</Hash>
</Codenesium>*/