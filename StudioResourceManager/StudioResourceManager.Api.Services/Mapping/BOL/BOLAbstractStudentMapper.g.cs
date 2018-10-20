using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class BOLAbstractStudentMapper
	{
		public virtual BOStudent MapModelToBO(
			int id,
			ApiStudentRequestModel model
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
				model.UserId,
				model.IsDeleted);
			return boStudent;
		}

		public virtual ApiStudentResponseModel MapBOToModel(
			BOStudent boStudent)
		{
			var model = new ApiStudentResponseModel();

			model.SetProperties(boStudent.Id, boStudent.Birthday, boStudent.Email, boStudent.EmailRemindersEnabled, boStudent.FamilyId, boStudent.FirstName, boStudent.IsAdult, boStudent.LastName, boStudent.Phone, boStudent.SmsRemindersEnabled, boStudent.UserId, boStudent.IsDeleted);

			return model;
		}

		public virtual List<ApiStudentResponseModel> MapBOToModel(
			List<BOStudent> items)
		{
			List<ApiStudentResponseModel> response = new List<ApiStudentResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>423e2220503d2340641d1d0ffdfd96e3</Hash>
</Codenesium>*/