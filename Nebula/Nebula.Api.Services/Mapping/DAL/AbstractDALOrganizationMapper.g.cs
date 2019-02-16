using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractDALOrganizationMapper
	{
		public virtual Organization MapModelToEntity(
			int id,
			ApiOrganizationServerRequestModel model
			)
		{
			Organization item = new Organization();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiOrganizationServerResponseModel MapEntityToModel(
			Organization item)
		{
			var model = new ApiOrganizationServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiOrganizationServerResponseModel> MapEntityToModel(
			List<Organization> items)
		{
			List<ApiOrganizationServerResponseModel> response = new List<ApiOrganizationServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d5e81d7e82307ab82e2dfc4a7c1fd45f</Hash>
</Codenesium>*/