using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public class DALStudentMapper : IDALStudentMapper
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
			if (item.FamilyIdNavigation != null)
			{
				var familyIdModel = new ApiFamilyServerResponseModel();
				familyIdModel.SetProperties(
					item.FamilyIdNavigation.Id,
					item.FamilyIdNavigation.Notes,
					item.FamilyIdNavigation.PrimaryContactEmail,
					item.FamilyIdNavigation.PrimaryContactFirstName,
					item.FamilyIdNavigation.PrimaryContactLastName,
					item.FamilyIdNavigation.PrimaryContactPhone);

				model.SetFamilyIdNavigation(familyIdModel);
			}

			if (item.UserIdNavigation != null)
			{
				var userIdModel = new ApiUserServerResponseModel();
				userIdModel.SetProperties(
					item.UserIdNavigation.Id,
					item.UserIdNavigation.Password,
					item.UserIdNavigation.Username);

				model.SetUserIdNavigation(userIdModel);
			}

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
    <Hash>22cea98e331ae500c6bf4cee47141aa4</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/