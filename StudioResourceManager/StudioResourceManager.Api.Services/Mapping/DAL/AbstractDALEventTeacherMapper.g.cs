using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractDALEventTeacherMapper
	{
		public virtual EventTeacher MapModelToEntity(
			int id,
			ApiEventTeacherServerRequestModel model
			)
		{
			EventTeacher item = new EventTeacher();
			item.SetProperties(
				id,
				model.EventId,
				model.TeacherId);
			return item;
		}

		public virtual ApiEventTeacherServerResponseModel MapEntityToModel(
			EventTeacher item)
		{
			var model = new ApiEventTeacherServerResponseModel();

			model.SetProperties(item.Id,
			                    item.EventId,
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
					item.EventIdNavigation.StudentNotes,
					item.EventIdNavigation.TeacherNotes);

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
    <Hash>74e9f072b874f0177a544a98c9547067</Hash>
</Codenesium>*/