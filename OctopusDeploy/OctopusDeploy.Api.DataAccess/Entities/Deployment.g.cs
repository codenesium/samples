using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("Deployment", Schema="dbo")]
	public partial class Deployment : AbstractEntity
	{
		public Deployment()
		{
		}

		public virtual void SetProperties(
			string channelId,
			DateTimeOffset created,
			string deployedBy,
			string deployedToMachineIds,
			string environmentId,
			string id,
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

		[MaxLength(50)]
		[Column("ChannelId")]
		public string ChannelId { get; private set; }

		[Column("Created")]
		public DateTimeOffset Created { get; private set; }

		[MaxLength(200)]
		[Column("DeployedBy")]
		public string DeployedBy { get; private set; }

		[Column("DeployedToMachineIds")]
		public string DeployedToMachineIds { get; private set; }

		[MaxLength(50)]
		[Column("EnvironmentId")]
		public string EnvironmentId { get; private set; }

		[Key]
		[MaxLength(50)]
		[Column("Id")]
		public string Id { get; private set; }

		[Column("JSON")]
		public string JSON { get; private set; }

		[MaxLength(200)]
		[Column("Name")]
		public string Name { get; private set; }

		[MaxLength(50)]
		[Column("ProjectGroupId")]
		public string ProjectGroupId { get; private set; }

		[MaxLength(50)]
		[Column("ProjectId")]
		public string ProjectId { get; private set; }

		[MaxLength(50)]
		[Column("ReleaseId")]
		public string ReleaseId { get; private set; }

		[MaxLength(50)]
		[Column("TaskId")]
		public string TaskId { get; private set; }

		[MaxLength(50)]
		[Column("TenantId")]
		public string TenantId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>95ba10c1208f8d0cc82581062ac3e3b6</Hash>
</Codenesium>*/