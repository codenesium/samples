using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects
{
	public abstract class AbstractBOLStudentMapper
	{
		public virtual DTOStudent MapModelToDTO(
			int id,
			ApiStudentRequestModel model
			)
		{
			DTOStudent dtoStudent = new DTOStudent();

			dtoStudent.SetProperties(
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
			return dtoStudent;
		}

		public virtual ApiStudentResponseModel MapDTOToModel(
			DTOStudent dtoStudent)
		{
			if (dtoStudent == null)
			{
				return null;
			}

			var model = new ApiStudentResponseModel();

			model.SetProperties(dtoStudent.Birthday, dtoStudent.Email, dtoStudent.EmailRemindersEnabled, dtoStudent.FamilyId, dtoStudent.FirstName, dtoStudent.Id, dtoStudent.IsAdult, dtoStudent.LastName, dtoStudent.Phone, dtoStudent.SmsRemindersEnabled, dtoStudent.StudioId);

			return model;
		}

		public virtual List<ApiStudentResponseModel> MapDTOToModel(
			List<DTOStudent> dtos)
		{
			List<ApiStudentResponseModel> response = new List<ApiStudentResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9b9e372281bfbcccdb1a37b867a5f791</Hash>
</Codenesium>*/