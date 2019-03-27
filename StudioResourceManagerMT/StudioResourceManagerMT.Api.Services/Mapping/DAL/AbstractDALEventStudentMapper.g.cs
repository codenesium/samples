using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractDALEventStudentMapper
	{
		public virtual EventStudent MapModelToEntity(
			int eventId,
			ApiEventStudentServerRequestModel model
			)
		{
			EventStudent item = new EventStudent();
			item.SetProperties(
				eventId,
				model.StudentId);
			return item;
		}

		public virtual ApiEventStudentServerResponseModel MapEntityToModel(
			EventStudent item)
		{
			var model = new ApiEventStudentServerResponseModel();

			model.SetProperties(item.EventId,
			                    item.StudentId);
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

			if (item.StudentIdNavigation != null)
			{
				var studentIdModel = new ApiStudentServerResponseModel();
				studentIdModel.SetProperties(
					item.StudentIdNavigation.Id,
					item.StudentIdNavigation.Birthday,
					item.StudentIdNavigation.Email,
					item.StudentIdNavigation.EmailRemindersEnabled,
					item.StudentIdNavigation.FamilyId,
					item.StudentIdNavigation.FirstName,
					item.StudentIdNavigation.IsAdult,
					item.StudentIdNavigation.LastName,
					item.StudentIdNavigation.Phone,
					item.StudentIdNavigation.SmsRemindersEnabled,
					item.StudentIdNavigation.UserId);

				model.SetStudentIdNavigation(studentIdModel);
			}

			return model;
		}

		public virtual List<ApiEventStudentServerResponseModel> MapEntityToModel(
			List<EventStudent> items)
		{
			List<ApiEventStudentServerResponseModel> response = new List<ApiEventStudentServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>7c2d9e0a575ac103f293d7ccb74a5e18</Hash>
</Codenesium>*/