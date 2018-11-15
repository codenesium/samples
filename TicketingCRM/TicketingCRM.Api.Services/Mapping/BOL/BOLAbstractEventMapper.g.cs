using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class BOLAbstractEventMapper
	{
		public virtual BOEvent MapModelToBO(
			int id,
			ApiEventServerRequestModel model
			)
		{
			BOEvent boEvent = new BOEvent();
			boEvent.SetProperties(
				id,
				model.Address1,
				model.Address2,
				model.CityId,
				model.Date,
				model.Description,
				model.EndDate,
				model.Facebook,
				model.Name,
				model.StartDate,
				model.Website);
			return boEvent;
		}

		public virtual ApiEventServerResponseModel MapBOToModel(
			BOEvent boEvent)
		{
			var model = new ApiEventServerResponseModel();

			model.SetProperties(boEvent.Id, boEvent.Address1, boEvent.Address2, boEvent.CityId, boEvent.Date, boEvent.Description, boEvent.EndDate, boEvent.Facebook, boEvent.Name, boEvent.StartDate, boEvent.Website);

			return model;
		}

		public virtual List<ApiEventServerResponseModel> MapBOToModel(
			List<BOEvent> items)
		{
			List<ApiEventServerResponseModel> response = new List<ApiEventServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0350150734283a6b8f162bce9f1fd702</Hash>
</Codenesium>*/