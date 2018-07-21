using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
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

                public virtual void SetProperties(
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

                [JsonProperty]
                public DateTimeOffset Assembled { get; private set; }

                [JsonProperty]
                public string ChannelId { get; private set; }

                [JsonProperty]
                public string JSON { get; private set; }

                [JsonProperty]
                public string ProjectDeploymentProcessSnapshotId { get; private set; }

                [JsonProperty]
                public string ProjectId { get; private set; }

                [JsonProperty]
                public string ProjectVariableSetSnapshotId { get; private set; }

                [JsonProperty]
                public string Version { get; private set; }
        }
}

/*<Codenesium>
    <Hash>cd1ceb045c5f5fca7bf5247d08d024d7</Hash>
</Codenesium>*/