using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class DALAbstractDeploymentHistoryMapper
	{
		public virtual DeploymentHistory MapBOToEF(
			BODeploymentHistory bo)
		{
			DeploymentHistory efDeploymentHistory = new DeploymentHistory();
			efDeploymentHistory.SetProperties(
				bo.ChannelId,
				bo.ChannelName,
				bo.CompletedTime,
				bo.Created,
				bo.DeployedBy,
				bo.DeploymentId,
				bo.DeploymentName,
				bo.DurationSeconds,
				bo.EnvironmentId,
				bo.EnvironmentName,
				bo.ProjectId,
				bo.ProjectName,
				bo.ProjectSlug,
				bo.QueueTime,
				bo.ReleaseId,
				bo.ReleaseVersion,
				bo.StartTime,
				bo.TaskId,
				bo.TaskState,
				bo.TenantId,
				bo.TenantName);
			return efDeploymentHistory;
		}

		public virtual BODeploymentHistory MapEFToBO(
			DeploymentHistory ef)
		{
			var bo = new BODeploymentHistory();

			bo.SetProperties(
				ef.DeploymentId,
				ef.ChannelId,
				ef.ChannelName,
				ef.CompletedTime,
				ef.Created,
				ef.DeployedBy,
				ef.DeploymentName,
				ef.DurationSeconds,
				ef.EnvironmentId,
				ef.EnvironmentName,
				ef.ProjectId,
				ef.ProjectName,
				ef.ProjectSlug,
				ef.QueueTime,
				ef.ReleaseId,
				ef.ReleaseVersion,
				ef.StartTime,
				ef.TaskId,
				ef.TaskState,
				ef.TenantId,
				ef.TenantName);
			return bo;
		}

		public virtual List<BODeploymentHistory> MapEFToBO(
			List<DeploymentHistory> records)
		{
			List<BODeploymentHistory> response = new List<BODeploymentHistory>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>52f93f1d2ed9c8a6c98e2a3c1dcf57fb</Hash>
</Codenesium>*/