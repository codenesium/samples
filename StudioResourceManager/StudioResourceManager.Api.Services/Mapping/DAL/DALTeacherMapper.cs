using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public class DALTeacherMapper : IDALTeacherMapper
	{
		public virtual Teacher MapModelToEntity(
			int id,
			ApiTeacherServerRequestModel model
			)
		{
			Teacher item = new Teacher();
			item.SetProperties(
				id,
				model.Birthday,
				model.Email,
				model.FirstName,
				model.LastName,
				model.Phone,
				model.UserId);
			return item;
		}

		public virtual ApiTeacherServerResponseModel MapEntityToModel(
			Teacher item)
		{
			var model = new ApiTeacherServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Birthday,
			                    item.Email,
			                    item.FirstName,
			                    item.LastName,
			                    item.Phone,
			                    item.UserId);
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

		public virtual List<ApiTeacherServerResponseModel> MapEntityToModel(
			List<Teacher> items)
		{
			List<ApiTeacherServerResponseModel> response = new List<ApiTeacherServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c02e0e3793172976810d0434f8728e11</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/