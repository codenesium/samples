using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class BOLAbstractStudentMapper
	{
		public virtual BOStudent MapModelToBO(
			int id,
			ApiStudentServerRequestModel model
			)
		{
			BOStudent boStudent = new BOStudent();
			boStudent.SetProperties(
				id,
				model.Birthday,
				model.Email,
				model.EmailRemindersEnabled,
				model.FamilyId,
				model.FirstName,
				model.IsAdult,
				model.LastName,
				model.Phone,
				model.SmsRemindersEnabled,
				model.UserId);
			return boStudent;
		}

		public virtual ApiStudentServerResponseModel MapBOToModel(
			BOStudent boStudent)
		{
			var model = new ApiStudentServerResponseModel();

			model.SetProperties(boStudent.Id, boStudent.Birthday, boStudent.Email, boStudent.EmailRemindersEnabled, boStudent.FamilyId, boStudent.FirstName, boStudent.IsAdult, boStudent.LastName, boStudent.Phone, boStudent.SmsRemindersEnabled, boStudent.UserId);

			return model;
		}

		public virtual List<ApiStudentServerResponseModel> MapBOToModel(
			List<BOStudent> items)
		{
			List<ApiStudentServerResponseModel> response = new List<ApiStudentServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f952b3e4460a01a86e6ca33416046506</Hash>
</Codenesium>*/