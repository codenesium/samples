using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Deployment", Schema="dbo")]
        public partial class Deployment: AbstractEntity
        {
                public Deployment()
                {
                }

                public void SetProperties(
                        string channelId,
                        DateTime created,
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

                [Column("ChannelId", TypeName="nvarchar(50)")]
                public string ChannelId { get; private set; }

                [Column("Created", TypeName="datetimeoffset")]
                public DateTime Created { get; private set; }

                [Column("DeployedBy", TypeName="nvarchar(200)")]
                public string DeployedBy { get; private set; }

                [Column("DeployedToMachineIds", TypeName="nvarchar(-1)")]
                public string DeployedToMachineIds { get; private set; }

                [Column("EnvironmentId", TypeName="nvarchar(50)")]
                public string EnvironmentId { get; private set; }

                [Key]
                [Column("Id", TypeName="nvarchar(50)")]
                public string Id { get; private set; }

                [Column("JSON", TypeName="nvarchar(-1)")]
                public string JSON { get; private set; }

                [Column("Name", TypeName="nvarchar(200)")]
                public string Name { get; private set; }

                [Column("ProjectGroupId", TypeName="nvarchar(50)")]
                public string ProjectGroupId { get; private set; }

                [Column("ProjectId", TypeName="nvarchar(50)")]
                public string ProjectId { get; private set; }

                [Column("ReleaseId", TypeName="nvarchar(50)")]
                public string ReleaseId { get; private set; }

                [Column("TaskId", TypeName="nvarchar(50)")]
                public string TaskId { get; private set; }

                [Column("TenantId", TypeName="nvarchar(50)")]
                public string TenantId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>2c64599c3dec00da220df6f2e30bb1bb</Hash>
</Codenesium>*/