using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class BOLAbstractDeploymentEnvironmentMapper
	{
		public virtual BODeploymentEnvironment MapModelToBO(
			string id,
			ApiDeploymentEnvironmentRequestModel model
			)
		{
			BODeploymentEnvironment boDeploymentEnvironment = new BODeploymentEnvironment();
			boDeploymentEnvironment.SetProperties(
				id,
				model.DataVersion,
				model.JSON,
				model.Name,
				model.SortOrder);
			return boDeploymentEnvironment;
		}

		public virtual ApiDeploymentEnvironmentResponseModel MapBOToModel(
			BODeploymentEnvironment boDeploymentEnvironment)
		{
			var model = new ApiDeploymentEnvironmentResponseModel();

			model.SetProperties(boDeploymentEnvironment.Id, boDeploymentEnvironment.DataVersion, boDeploymentEnvironment.JSON, boDeploymentEnvironment.Name, boDeploymentEnvironment.SortOrder);

			return model;
		}

		public virtual List<ApiDeploymentEnvironmentResponseModel> MapBOToModel(
			List<BODeploymentEnvironment> items)
		{
			List<ApiDeploymentEnvironmentResponseModel> response = new List<ApiDeploymentEnvironmentResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>25cc9448da93d9d440f46a0b81e53440</Hash>
</Codenesium>*/