using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
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
				model.StudentNote,
				model.TeacherNote);
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
			                    item.StudentNote,
			                    item.TeacherNote);
			if (item.EventStatusIdNavigation != null)
			{
				var eventStatusIdModel = new ApiEventStatusServerResponseModel();
				eventStatusIdModel.SetProperties(
					item.Id,
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
    <Hash>b9988e4075dee120d61cfaf0762e8255</Hash>
</Codenesium>*/