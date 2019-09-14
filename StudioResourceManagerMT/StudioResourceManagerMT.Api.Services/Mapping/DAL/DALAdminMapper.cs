using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class DALAdminMapper : IDALAdminMapper
	{
		public virtual Admin MapModelToEntity(
			int id,
			ApiAdminServerRequestModel model
			)
		{
			Admin item = new Admin();
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

		public virtual ApiAdminServerResponseModel MapEntityToModel(
			Admin item)
		{
			var model = new ApiAdminServerResponseModel();

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

		public virtual List<ApiAdminServerResponseModel> MapEntityToModel(
			List<Admin> items)
		{
			List<ApiAdminServerResponseModel> response = new List<ApiAdminServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>92bb9201f06613a82d77ab2325fd8b11</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/