using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class BOLAbstractDeploymentHistoryMapper
	{
		public virtual BODeploymentHistory MapModelToBO(
			string deploymentId,
			ApiDeploymentHistoryRequestModel model
			)
		{
			BODeploymentHistory boDeploymentHistory = new BODeploymentHistory();
			boDeploymentHistory.SetProperties(
				deploymentId,
				model.ChannelId,
				model.ChannelName,
				model.CompletedTime,
				model.Created,
				model.DeployedBy,
				model.DeploymentName,
				model.DurationSeconds,
				model.EnvironmentId,
				model.EnvironmentName,
				model.ProjectId,
				model.ProjectName,
				model.ProjectSlug,
				model.QueueTime,
				model.ReleaseId,
				model.ReleaseVersion,
				model.StartTime,
				model.TaskId,
				model.TaskState,
				model.TenantId,
				model.TenantName);
			return boDeploymentHistory;
		}

		public virtual ApiDeploymentHistoryResponseModel MapBOToModel(
			BODeploymentHistory boDeploymentHistory)
		{
			var model = new ApiDeploymentHistoryResponseModel();

			model.SetProperties(boDeploymentHistory.DeploymentId, boDeploymentHistory.ChannelId, boDeploymentHistory.ChannelName, boDeploymentHistory.CompletedTime, boDeploymentHistory.Created, boDeploymentHistory.DeployedBy, boDeploymentHistory.DeploymentName, boDeploymentHistory.DurationSeconds, boDeploymentHistory.EnvironmentId, boDeploymentHistory.EnvironmentName, boDeploymentHistory.ProjectId, boDeploymentHistory.ProjectName, boDeploymentHistory.ProjectSlug, boDeploymentHistory.QueueTime, boDeploymentHistory.ReleaseId, boDeploymentHistory.ReleaseVersion, boDeploymentHistory.StartTime, boDeploymentHistory.TaskId, boDeploymentHistory.TaskState, boDeploymentHistory.TenantId, boDeploymentHistory.TenantName);

			return model;
		}

		public virtual List<ApiDeploymentHistoryResponseModel> MapBOToModel(
			List<BODeploymentHistory> items)
		{
			List<ApiDeploymentHistoryResponseModel> response = new List<ApiDeploymentHistoryResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>98f7e963f5a923426b5d984a7856d545</Hash>
</Codenesium>*/