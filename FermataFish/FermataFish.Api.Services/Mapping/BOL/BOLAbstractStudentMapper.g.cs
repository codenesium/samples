using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
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
				model.StudioId);
			return boStudent;
		}

		public virtual ApiStudentResponseModel MapBOToModel(
			BOStudent boStudent)
		{
			var model = new ApiStudentResponseModel();

			model.SetProperties(boStudent.Id, boStudent.Birthday, boStudent.Email, boStudent.EmailRemindersEnabled, boStudent.FamilyId, boStudent.FirstName, boStudent.IsAdult, boStudent.LastName, boStudent.Phone, boStudent.SmsRemindersEnabled, boStudent.StudioId);

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
    <Hash>4584afc0b1080269231d6ea9ca7ddde7</Hash>
</Codenesium>*/