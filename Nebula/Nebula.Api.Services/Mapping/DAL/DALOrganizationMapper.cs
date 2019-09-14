using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public class DALOrganizationMapper : IDALOrganizationMapper
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
    <Hash>ab35f12aec8ba16ba41dcec04f351332</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/