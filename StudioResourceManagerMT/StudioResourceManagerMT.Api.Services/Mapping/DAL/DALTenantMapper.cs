using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class DALTenantMapper : IDALTenantMapper
	{
		public virtual Tenant MapModelToEntity(
			int id,
			ApiTenantServerRequestModel model
			)
		{
			Tenant item = new Tenant();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiTenantServerResponseModel MapEntityToModel(
			Tenant item)
		{
			var model = new ApiTenantServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiTenantServerResponseModel> MapEntityToModel(
			List<Tenant> items)
		{
			List<ApiTenantServerResponseModel> response = new List<ApiTenantServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>18cf289cfc5571ea757f8df877a2f4b9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/