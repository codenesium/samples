using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiReleaseRequestModel : AbstractApiRequestModel
        {
                public ApiReleaseRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        DateTimeOffset assembled,
                        string channelId,
                        string jSON,
                        string projectDeploymentProcessSnapshotId,
                        string projectId,
                        string projectVariableSetSnapshotId,
                        string version)
                {
                        this.Assembled = assembled;
                        this.ChannelId = channelId;
                        this.JSON = jSON;
                        this.ProjectDeploymentProcessSnapshotId = projectDeploymentProcessSnapshotId;
                        this.ProjectId = projectId;
                        this.ProjectVariableSetSnapshotId = projectVariableSetSnapshotId;
                        this.Version = version;
                }

                private DateTimeOffset assembled;

                [Required]
                public DateTimeOffset Assembled
                {
                        get
                        {
                                return this.assembled;
                        }

                        set
                        {
                                this.assembled = value;
                        }
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

                private string projectDeploymentProcessSnapshotId;

                [Required]
                public string ProjectDeploymentProcessSnapshotId
                {
                        get
                        {
                                return this.projectDeploymentProcessSnapshotId;
                        }

                        set
                        {
                                this.projectDeploymentProcessSnapshotId = value;
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

                private string projectVariableSetSnapshotId;

                [Required]
                public string ProjectVariableSetSnapshotId
                {
                        get
                        {
                                return this.projectVariableSetSnapshotId;
                        }

                        set
                        {
                                this.projectVariableSetSnapshotId = value;
                        }
                }

                private string version;

                [Required]
                public string Version
                {
                        get
                        {
                                return this.version;
                        }

                        set
                        {
                                this.version = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>0b43b54a19a162c9575e2448ee11f32e</Hash>
</Codenesium>*/