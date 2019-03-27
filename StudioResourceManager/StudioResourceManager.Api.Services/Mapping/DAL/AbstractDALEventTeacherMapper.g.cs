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
			if (item.IdNavigation != null)
			{
				var idModel = new ApiEventServerResponseModel();
				idModel.SetProperties(
					item.IdNavigation.Id,
					item.IdNavigation.ActualEndDate,
					item.IdNavigation.ActualStartDate,
					item.IdNavigation.BillAmount,
					item.IdNavigation.EventStatusId,
					item.IdNavigation.ScheduledEndDate,
					item.IdNavigation.ScheduledStartDate,
					item.IdNavigation.StudentNotes,
					item.IdNavigation.TeacherNotes);

				model.SetIdNavigation(idModel);
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
    <Hash>e70b02137b55d395f582406ae91601e5</Hash>
</Codenesium>*/