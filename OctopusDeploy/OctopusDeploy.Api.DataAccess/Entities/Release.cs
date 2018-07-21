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

                [Column("ChannelId")]
                public string ChannelId { get; private set; }

                [Key]
                [Column("Id")]
                public string Id { get; private set; }

                [Column("JSON")]
                public string JSON { get; private set; }

                [Column("ProjectDeploymentProcessSnapshotId")]
                public string ProjectDeploymentProcessSnapshotId { get; private set; }

                [Column("ProjectId")]
                public string ProjectId { get; private set; }

                [Column("ProjectVariableSetSnapshotId")]
                public string ProjectVariableSetSnapshotId { get; private set; }

                [Column("Version")]
                public string Version { get; private set; }
        }
}

/*<Codenesium>
    <Hash>7326cf29eb95c4a69514ef58f0686377</Hash>
</Codenesium>*/