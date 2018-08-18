using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("Release", Schema="dbo")]
	public partial class Release : AbstractEntity
	{
		public Release()
		{
		}

		public virtual void SetProperties(
			DateTimeOffset assembled,
			string channelId,
			string id,
			string jSON,
			string projectDeploymentProcessSnapshotId,
			string projectId,
			string projectVariableSetSnapshotId,
			string version)
		{
			this.Assembled = assembled;
			this.ChannelId = channelId;
			this.Id = id;
			this.JSON = jSON;
			this.ProjectDeploymentProcessSnapshotId = projectDeploymentProcessSnapshotId;
			this.ProjectId = projectId;
			this.ProjectVariableSetSnapshotId = projectVariableSetSnapshotId;
			this.Version = version;
		}

		[Column("Assembled")]
		public DateTimeOffset Assembled { get; private set; }

		[MaxLength(50)]
		[Column("ChannelId")]
		public string ChannelId { get; private set; }

		[Key]
		[MaxLength(150)]
		[Column("Id")]
		public string Id { get; private set; }

		[Column("JSON")]
		public string JSON { get; private set; }

		[MaxLength(150)]
		[Column("ProjectDeploymentProcessSnapshotId")]
		public string ProjectDeploymentProcessSnapshotId { get; private set; }

		[MaxLength(150)]
		[Column("ProjectId")]
		public string ProjectId { get; private set; }

		[MaxLength(150)]
		[Column("ProjectVariableSetSnapshotId")]
		public string ProjectVariableSetSnapshotId { get; private set; }

		[MaxLength(100)]
		[Column("Version")]
		public string Version { get; private set; }
	}
}

/*<Codenesium>
    <Hash>364616b679d5f9b6217e39567e26a16b</Hash>
</Codenesium>*/