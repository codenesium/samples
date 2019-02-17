using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractDALStudentMapper
	{
		public virtual Student MapModelToEntity(
			int id,
			ApiStudentServerRequestModel model
			)
		{
			Student item = new Student();
			item.SetProperties(
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
			return item;
		}

		public virtual ApiStudentServerResponseModel MapEntityToModel(
			Student item)
		{
			var model = new ApiStudentServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Birthday,
			                    item.Email,
			                    item.EmailRemindersEnabled,
			                    item.FamilyId,
			                    item.FirstName,
			                    item.IsAdult,
			                    item.LastName,
			                    item.Phone,
			                    item.SmsRemindersEnabled,
			                    item.UserId);

			return model;
		}

		public virtual List<ApiStudentServerResponseModel> MapEntityToModel(
			List<Student> items)
		{
			List<ApiStudentServerResponseModel> response = new List<ApiStudentServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>26aa204aab3d21cdbbd84a63ad851319</Hash>
</Codenesium>*/