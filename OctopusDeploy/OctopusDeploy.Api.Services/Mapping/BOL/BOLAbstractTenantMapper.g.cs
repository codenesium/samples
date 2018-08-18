using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class BOLAbstractTenantMapper
	{
		public virtual BOTenant MapModelToBO(
			string id,
			ApiTenantRequestModel model
			)
		{
			BOTenant boTenant = new BOTenant();
			boTenant.SetProperties(
				id,
				model.DataVersion,
				model.JSON,
				model.Name,
				model.ProjectIds,
				model.TenantTags);
			return boTenant;
		}

		public virtual ApiTenantResponseModel MapBOToModel(
			BOTenant boTenant)
		{
			var model = new ApiTenantResponseModel();

			model.SetProperties(boTenant.Id, boTenant.DataVersion, boTenant.JSON, boTenant.Name, boTenant.ProjectIds, boTenant.TenantTags);

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
    <Hash>b06da12f08caed4983925aad4741c293</Hash>
</Codenesium>*/