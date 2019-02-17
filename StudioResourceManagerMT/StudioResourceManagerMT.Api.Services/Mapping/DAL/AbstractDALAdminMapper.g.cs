using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractDALAdminMapper
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
    <Hash>7aa50d588bc5473bb144e578b94dccb0</Hash>
</Codenesium>*/