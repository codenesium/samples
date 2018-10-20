using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class BOLAbstractEventMapper
	{
		public virtual BOEvent MapModelToBO(
			int id,
			ApiEventRequestModel model
			)
		{
			BOEvent boEvent = new BOEvent();
			boEvent.SetProperties(
				id,
				model.ActualEndDate,
				model.ActualStartDate,
				model.BillAmount,
				model.EventStatusId,
				model.ScheduledEndDate,
				model.ScheduledStartDate,
				model.StudentNote,
				model.TeacherNote,
				model.IsDeleted);
			return boEvent;
		}

		public virtual ApiEventResponseModel MapBOToModel(
			BOEvent boEvent)
		{
			var model = new ApiEventResponseModel();

			model.SetProperties(boEvent.Id, boEvent.ActualEndDate, boEvent.ActualStartDate, boEvent.BillAmount, boEvent.EventStatusId, boEvent.ScheduledEndDate, boEvent.ScheduledStartDate, boEvent.StudentNote, boEvent.TeacherNote, boEvent.IsDeleted);

			return model;
		}

		public virtual List<ApiEventResponseModel> MapBOToModel(
			List<BOEvent> items)
		{
			List<ApiEventResponseModel> response = new List<ApiEventResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f8c9151daeaf7bd0a9146f0540d47cd4</Hash>
</Codenesium>*/