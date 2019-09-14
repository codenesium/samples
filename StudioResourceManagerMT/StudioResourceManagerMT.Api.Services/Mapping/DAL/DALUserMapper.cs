using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>ee3c7a9ae43e54af0ef120fc4c9420ba</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/