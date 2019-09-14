using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public class DALUserMapper : IDALUserMapper
	{
		public virtual User MapModelToEntity(
			int id,
			ApiUserServerRequestModel model
			)
		{
			User item = new User();
			item.SetProperties(
				id,
				model.Password,
				model.Username);
			return item;
		}

		public virtual ApiUserServerResponseModel MapEntityToModel(
			User item)
		{
			var model = new ApiUserServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Password,
			                    item.Username);

			return model;
		}

		public virtual List<ApiUserServerResponseModel> MapEntityToModel(
			List<User> items)
		{
			List<ApiUserServerResponseModel> response = new List<ApiUserServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>82d53128629da484bf42f14fd92881d5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/