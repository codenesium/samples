using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Deployment", Schema="dbo")]
        public partial class Deployment : AbstractEntity
        {
                public Deployment()
                {
                }

                public void SetProperties(
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

                [Column("ChannelId")]
                public string ChannelId { get; private set; }

                [Column("Created")]
                public DateTimeOffset Created { get; private set; }

                [Column("DeployedBy")]
                public string DeployedBy { get; private set; }

                [Column("DeployedToMachineIds")]
                public string DeployedToMachineIds { get; private set; }

                [Column("EnvironmentId")]
                public string EnvironmentId { get; private set; }

                [Key]
                [Column("Id")]
                public string Id { get; private set; }

                [Column("JSON")]
                public string JSON { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }

                [Column("ProjectGroupId")]
                public string ProjectGroupId { get; private set; }

                [Column("ProjectId")]
                public string ProjectId { get; private set; }

                [Column("ReleaseId")]
                public string ReleaseId { get; private set; }

                [Column("TaskId")]
                public string TaskId { get; private set; }

                [Column("TenantId")]
                public string TenantId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>0043484d5a78619976f8d4b717280865</Hash>
</Codenesium>*/