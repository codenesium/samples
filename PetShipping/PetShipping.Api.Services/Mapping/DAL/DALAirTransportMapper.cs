using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public class DALAirTransportMapper : IDALAirTransportMapper
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
    <Hash>8c85eb61f7015a8caa74a495657e0b52</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/