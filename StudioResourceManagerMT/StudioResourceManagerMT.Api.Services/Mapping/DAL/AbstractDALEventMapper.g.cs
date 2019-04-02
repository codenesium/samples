using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractDALEventMapper
	{
		public virtual Event MapModelToEntity(
			int id,
			ApiEventServerRequestModel model
			)
		{
			Event item = new Event();
			item.SetProperties(
				id,
				model.ActualEndDate,
				model.ActualStartDate,
				model.BillAmount,
				model.EventStatusId,
				model.ScheduledEndDate,
				model.ScheduledStartDate,
				model.StudentNotes,
				model.TeacherNotes);
			return item;
		}

		public virtual ApiEventServerResponseModel MapEntityToModel(
			Event item)
		{
			var model = new ApiEventServerResponseModel();

			model.SetProperties(item.Id,
			                    item.ActualEndDate,
			                    item.ActualStartDate,
			                    item.BillAmount,
			                    item.EventStatusId,
			                    item.ScheduledEndDate,
			                    item.ScheduledStartDate,
			                    item.StudentNotes,
			                    item.TeacherNotes);
			if (item.EventStatusIdNavigation != null)
			{
				var eventStatusIdModel = new ApiEventStatusServerResponseModel();
				eventStatusIdModel.SetProperties(
					item.EventStatusIdNavigation.Id,
					item.EventStatusIdNavigation.Name);

				model.SetEventStatusIdNavigation(eventStatusIdModel);
			}

			return model;
		}

		public virtual List<ApiEventServerResponseModel> MapEntityToModel(
			List<Event> items)
		{
			List<ApiEventServerResponseModel> response = new List<ApiEventServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>eb2ef4f7bb3c96c87a9cfd6f8ea1e8f9</Hash>
</Codenesium>*/