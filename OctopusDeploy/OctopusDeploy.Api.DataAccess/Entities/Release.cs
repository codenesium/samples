using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Release", Schema="dbo")]
        public partial class Release: AbstractEntity
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

                [Column("Assembled", TypeName="datetimeoffset")]
                public DateTimeOffset Assembled { get; private set; }

                [Column("ChannelId", TypeName="nvarchar(50)")]
                public string ChannelId { get; private set; }

                [Key]
                [Column("Id", TypeName="nvarchar(150)")]
                public string Id { get; private set; }

                [Column("JSON", TypeName="nvarchar(-1)")]
                public string JSON { get; private set; }

                [Column("ProjectDeploymentProcessSnapshotId", TypeName="nvarchar(150)")]
                public string ProjectDeploymentProcessSnapshotId { get; private set; }

                [Column("ProjectId", TypeName="nvarchar(150)")]
                public string ProjectId { get; private set; }

                [Column("ProjectVariableSetSnapshotId", TypeName="nvarchar(150)")]
                public string ProjectVariableSetSnapshotId { get; private set; }

                [Column("Version", TypeName="nvarchar(100)")]
                public string Version { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a8c1b60ba9a84686ed794794860704cc</Hash>
</Codenesium>*/