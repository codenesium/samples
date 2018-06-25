using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiDeploymentRequestModel : AbstractApiRequestModel
        {
                public ApiDeploymentRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
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
                        this.JSON = jSON;
                        this.Name = name;
                        this.ProjectGroupId = projectGroupId;
                        this.ProjectId = projectId;
                        this.ReleaseId = releaseId;
                        this.TaskId = taskId;
                        this.TenantId = tenantId;
                }

                private string channelId;

                [Required]
                public string ChannelId
                {
                        get
                        {
                                return this.channelId;
                        }

                        set
                        {
                                this.channelId = value;
                        }
                }

                private DateTimeOffset created;

                [Required]
                public DateTimeOffset Created
                {
                        get
                        {
                                return this.created;
                        }

                        set
                        {
                                this.created = value;
                        }
                }

                private string deployedBy;

                [Required]
                public string DeployedBy
                {
                        get
                        {
                                return this.deployedBy;
                        }

                        set
                        {
                                this.deployedBy = value;
                        }
                }

                private string deployedToMachineIds;

                public string DeployedToMachineIds
                {
                        get
                        {
                                return this.deployedToMachineIds;
                        }

                        set
                        {
                                this.deployedToMachineIds = value;
                        }
                }

                private string environmentId;

                [Required]
                public string EnvironmentId
                {
                        get
                        {
                                return this.environmentId;
                        }

                        set
                        {
                                this.environmentId = value;
                        }
                }

                private string jSON;

                [Required]
                public string JSON
                {
                        get
                        {
                                return this.jSON;
                        }

                        set
                        {
                                this.jSON = value;
                        }
                }

                private string name;

                [Required]
                public string Name
                {
                        get
                        {
                                return this.name;
                        }

                        set
                        {
                                this.name = value;
                        }
                }

                private string projectGroupId;

                [Required]
                public string ProjectGroupId
                {
                        get
                        {
                                return this.projectGroupId;
                        }

                        set
                        {
                                this.projectGroupId = value;
                        }
                }

                private string projectId;

                [Required]
                public string ProjectId
                {
                        get
                        {
                                return this.projectId;
                        }

                        set
                        {
                                this.projectId = value;
                        }
                }

                private string releaseId;

                [Required]
                public string ReleaseId
                {
                        get
                        {
                                return this.releaseId;
                        }

                        set
                        {
                                this.releaseId = value;
                        }
                }

                private string taskId;

                public string TaskId
                {
                        get
                        {
                                return this.taskId;
                        }

                        set
                        {
                                this.taskId = value;
                        }
                }

                private string tenantId;

                public string TenantId
                {
                        get
                        {
                                return this.tenantId;
                        }

                        set
                        {
                                this.tenantId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>399392e455cb9610fa44811b5cd7f66c</Hash>
</Codenesium>*/