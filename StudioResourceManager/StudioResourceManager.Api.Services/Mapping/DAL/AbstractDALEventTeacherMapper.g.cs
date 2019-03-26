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
				model.TeacherId);
			return item;
		}

		public virtual ApiEventTeacherServerResponseModel MapEntityToModel(
			EventTeacher item)
		{
			var model = new ApiEventTeacherServerResponseModel();

			model.SetProperties(item.Id,
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
					item.IdNavigation.StudentNote,
					item.IdNavigation.TeacherNote);

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
    <Hash>ced72b92a9ca26d145145fed2695b4d7</Hash>
</Codenesium>*/