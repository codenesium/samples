using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public abstract class BOLAbstractStudentMapper
	{
		public virtual BOStudent MapModelToBO(
			int id,
			ApiStudentRequestModel model
			)
		{
			BOStudent BOStudent = new BOStudent();

			BOStudent.SetProperties(
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
			return BOStudent;
		}

		public virtual ApiStudentResponseModel MapBOToModel(
			BOStudent BOStudent)
		{
			if (BOStudent == null)
			{
				return null;
			}

			var model = new ApiStudentResponseModel();

			model.SetProperties(BOStudent.Birthday, BOStudent.Email, BOStudent.EmailRemindersEnabled, BOStudent.FamilyId, BOStudent.FirstName, BOStudent.Id, BOStudent.IsAdult, BOStudent.LastName, BOStudent.Phone, BOStudent.SmsRemindersEnabled, BOStudent.StudioId);

			return model;
		}

		public virtual List<ApiStudentResponseModel> MapBOToModel(
			List<BOStudent> BOs)
		{
			List<ApiStudentResponseModel> response = new List<ApiStudentResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>472c9802352708881073c3a2aab205be</Hash>
</Codenesium>*/