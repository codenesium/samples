using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractDALTenantMapper
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
    <Hash>2a7f51dffc2fba0d1c12f773bc22df9f</Hash>
</Codenesium>*/