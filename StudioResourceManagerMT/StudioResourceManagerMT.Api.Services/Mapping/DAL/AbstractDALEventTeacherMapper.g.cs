using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractDALEventTeacherMapper
	{
		public virtual EventTeacher MapModelToEntity(
			int eventId,
			ApiEventTeacherServerRequestModel model
			)
		{
			EventTeacher item = new EventTeacher();
			item.SetProperties(
				eventId,
				model.TeacherId);
			return item;
		}

		public virtual ApiEventTeacherServerResponseModel MapEntityToModel(
			EventTeacher item)
		{
			var model = new ApiEventTeacherServerResponseModel();

			model.SetProperties(item.EventId,
			                    item.TeacherId);
			if (item.EventIdNavigation != null)
			{
				var eventIdModel = new ApiEventServerResponseModel();
				eventIdModel.SetProperties(
					item.EventIdNavigation.Id,
					item.EventIdNavigation.ActualEndDate,
					item.EventIdNavigation.ActualStartDate,
					item.EventIdNavigation.BillAmount,
					item.EventIdNavigation.EventStatusId,
					item.EventIdNavigation.ScheduledEndDate,
					item.EventIdNavigation.ScheduledStartDate,
					item.EventIdNavigation.StudentNote,
					item.EventIdNavigation.TeacherNote);

				model.SetEventIdNavigation(eventIdModel);
			}

			if (item.TeacherIdNavigation != null)
			{
				var teacherIdModel = new ApiTeacherServerResponseModel();
				teacherIdModel.SetProperties(
					item.TeacherIdNavigation.Id,
					item.TeacherIdNavigation.Birthday,
					item.TeacherIdNavigation.Email,
					item.TeacherIdNavigation.FirstName,
					item.TeacherIdNavigation.LastName,
					item.TeacherIdNavigation.Phone,
					item.TeacherIdNavigation.UserId);

				model.SetTeacherIdNavigation(teacherIdModel);
			}

			return model;
		}

		public virtual List<ApiEventTeacherServerResponseModel> MapEntityToModel(
			List<EventTeacher> items)
		{
			List<ApiEventTeacherServerResponseModel> response = new List<ApiEventTeacherServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>bd1bbc669fb0c97bffa72a565c3978b0</Hash>
</Codenesium>*/