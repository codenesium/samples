using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiReleaseResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
                        DateTimeOffset assembled,
                        string channelId,
                        string jSON,
                        string projectDeploymentProcessSnapshotId,
                        string projectId,
                        string projectVariableSetSnapshotId,
                        string version)
                {
                        this.Id = id;
                        this.Assembled = assembled;
                        this.ChannelId = channelId;
                        this.JSON = jSON;
                        this.ProjectDeploymentProcessSnapshotId = projectDeploymentProcessSnapshotId;
                        this.ProjectId = projectId;
                        this.ProjectVariableSetSnapshotId = projectVariableSetSnapshotId;
                        this.Version = version;
                }

                [Required]
                [JsonProperty]
                public DateTimeOffset Assembled { get; private set; }

                [Required]
                [JsonProperty]
                public string ChannelId { get; private set; }

                [Required]
                [JsonProperty]
                public string Id { get; private set; }

                [Required]
                [JsonProperty]
                public string JSON { get; private set; }

                [Required]
                [JsonProperty]
                public string ProjectDeploymentProcessSnapshotId { get; private set; }

                [Required]
                [JsonProperty]
                public string ProjectId { get; private set; }

                [Required]
                [JsonProperty]
                public string ProjectVariableSetSnapshotId { get; private set; }

                [Required]
                [JsonProperty]
                public string Version { get; private set; }
        }
}

/*<Codenesium>
    <Hash>1e90abb12b641a2500fe186172e4d9ca</Hash>
</Codenesium>*/