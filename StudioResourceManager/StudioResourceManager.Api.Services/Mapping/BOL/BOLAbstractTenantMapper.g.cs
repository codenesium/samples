using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class BOLAbstractTenantMapper
	{
		public virtual BOTenant MapModelToBO(
			int id,
			ApiTenantRequestModel model
			)
		{
			BOTenant boTenant = new BOTenant();
			boTenant.SetProperties(
				id,
				model.Name);
			return boTenant;
		}

		public virtual ApiTenantResponseModel MapBOToModel(
			BOTenant boTenant)
		{
			var model = new ApiTenantResponseModel();

			model.SetProperties(boTenant.Id, boTenant.Name);

			return model;
		}

		public virtual List<ApiTenantResponseModel> MapBOToModel(
			List<BOTenant> items)
		{
			List<ApiTenantResponseModel> response = new List<ApiTenantResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>570f7acebb94101f508b3850bbcc438b</Hash>
</Codenesium>*/