using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Release", Schema="dbo")]
        public partial class Release : AbstractEntity
        {
                public Release()
                {
                }

                public void SetProperties(
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
    <Hash>c9685f4986d976841406fcf26180ad62</Hash>
</Codenesium>*/