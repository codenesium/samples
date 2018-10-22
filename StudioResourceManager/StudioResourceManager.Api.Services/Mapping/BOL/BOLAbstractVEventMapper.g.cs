using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class BOLAbstractVEventMapper
	{
		public virtual BOVEvent MapModelToBO(
			int id,
			ApiVEventRequestModel model
			)
		{
			BOVEvent boVEvent = new BOVEvent();
			boVEvent.SetProperties(
				id,
				model.ActualEndDate,
				model.ActualStartDate,
				model.BillAmount,
				model.EventStatusId,
				model.ScheduledEndDate,
				model.ScheduledStartDate);
			return boVEvent;
		}

		public virtual ApiVEventResponseModel MapBOToModel(
			BOVEvent boVEvent)
		{
			var model = new ApiVEventResponseModel();

			model.SetProperties(boVEvent.Id, boVEvent.ActualEndDate, boVEvent.ActualStartDate, boVEvent.BillAmount, boVEvent.EventStatusId, boVEvent.ScheduledEndDate, boVEvent.ScheduledStartDate);

			return model;
		}

		public virtual List<ApiVEventResponseModel> MapBOToModel(
			List<BOVEvent> items)
		{
			List<ApiVEventResponseModel> response = new List<ApiVEventResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>712d614f38117e38156b2d38e97c317b</Hash>
</Codenesium>*/