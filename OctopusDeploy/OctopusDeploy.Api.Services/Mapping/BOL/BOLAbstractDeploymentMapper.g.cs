using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class BOLAbstractDeploymentMapper
	{
		public virtual BODeployment MapModelToBO(
			string id,
			ApiDeploymentRequestModel model
			)
		{
			BODeployment boDeployment = new BODeployment();
			boDeployment.SetProperties(
				id,
				model.ChannelId,
				model.Created,
				model.DeployedBy,
				model.DeployedToMachineIds,
				model.EnvironmentId,
				model.JSON,
				model.Name,
				model.ProjectGroupId,
				model.ProjectId,
				model.ReleaseId,
				model.TaskId,
				model.TenantId);
			return boDeployment;
		}

		public virtual ApiDeploymentResponseModel MapBOToModel(
			BODeployment boDeployment)
		{
			var model = new ApiDeploymentResponseModel();

			model.SetProperties(boDeployment.Id, boDeployment.ChannelId, boDeployment.Created, boDeployment.DeployedBy, boDeployment.DeployedToMachineIds, boDeployment.EnvironmentId, boDeployment.JSON, boDeployment.Name, boDeployment.ProjectGroupId, boDeployment.ProjectId, boDeployment.ReleaseId, boDeployment.TaskId, boDeployment.TenantId);

			return model;
		}

		public virtual List<ApiDeploymentResponseModel> MapBOToModel(
			List<BODeployment> items)
		{
			List<ApiDeploymentResponseModel> response = new List<ApiDeploymentResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>65d9fab633fb81501c877a83f3fc1969</Hash>
</Codenesium>*/