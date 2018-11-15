using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
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
				model.ActualEndDate,
				model.ActualStartDate,
				model.BillAmount,
				model.EventStatusId,
				model.ScheduledEndDate,
				model.ScheduledStartDate,
				model.StudentNote,
				model.TeacherNote);
			return boEvent;
		}

		public virtual ApiEventServerResponseModel MapBOToModel(
			BOEvent boEvent)
		{
			var model = new ApiEventServerResponseModel();

			model.SetProperties(boEvent.Id, boEvent.ActualEndDate, boEvent.ActualStartDate, boEvent.BillAmount, boEvent.EventStatusId, boEvent.ScheduledEndDate, boEvent.ScheduledStartDate, boEvent.StudentNote, boEvent.TeacherNote);

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
    <Hash>f90a30d55a7be675b36b5b366c74a31b</Hash>
</Codenesium>*/