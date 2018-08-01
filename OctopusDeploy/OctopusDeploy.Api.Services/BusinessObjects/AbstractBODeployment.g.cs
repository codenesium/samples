using Codenesium.DataConversionExtensions;
using System;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractBODeployment : AbstractBusinessObject
	{
		public AbstractBODeployment()
			: base()
		{
		}

		public virtual void SetProperties(string id,
		                                  string channelId,
		                                  DateTimeOffset created,
		                                  string deployedBy,
		                                  string deployedToMachineIds,
		                                  string environmentId,
		                                  string jSON,
		                                  string name,
		                                  string projectGroupId,
		                                  string projectId,
		                                  string releaseId,
		                                  string taskId,
		                                  string tenantId)
		{
			this.ChannelId = channelId;
			this.Created = created;
			this.DeployedBy = deployedBy;
			this.DeployedToMachineIds = deployedToMachineIds;
			this.EnvironmentId = environmentId;
			this.Id = id;
			this.JSON = jSON;
			this.Name = name;
			this.ProjectGroupId = projectGroupId;
			this.ProjectId = projectId;
			this.ReleaseId = releaseId;
			this.TaskId = taskId;
			this.TenantId = tenantId;
		}

		public string ChannelId { get; private set; }

		public DateTimeOffset Created { get; private set; }

		public string DeployedBy { get; private set; }

		public string DeployedToMachineIds { get; private set; }

		public string EnvironmentId { get; private set; }

		public string Id { get; private set; }

		public string JSON { get; private set; }

		public string Name { get; private set; }

		public string ProjectGroupId { get; private set; }

		public string ProjectId { get; private set; }

		public string ReleaseId { get; private set; }

		public string TaskId { get; private set; }

		public string TenantId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b5597a7d1404e8ea076bd8d6d7507d4d</Hash>
</Codenesium>*/