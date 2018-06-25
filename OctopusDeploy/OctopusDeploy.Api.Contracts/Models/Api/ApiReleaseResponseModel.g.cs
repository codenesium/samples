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

                public DateTimeOffset Assembled { get; private set; }

                public string ChannelId { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string ProjectDeploymentProcessSnapshotId { get; private set; }

                public string ProjectId { get; private set; }

                public string ProjectVariableSetSnapshotId { get; private set; }

                public string Version { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeAssembledValue { get; set; } = true;

                public bool ShouldSerializeAssembled()
                {
                        return this.ShouldSerializeAssembledValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeChannelIdValue { get; set; } = true;

                public bool ShouldSerializeChannelId()
                {
                        return this.ShouldSerializeChannelIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeJSONValue { get; set; } = true;

                public bool ShouldSerializeJSON()
                {
                        return this.ShouldSerializeJSONValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeProjectDeploymentProcessSnapshotIdValue { get; set; } = true;

                public bool ShouldSerializeProjectDeploymentProcessSnapshotId()
                {
                        return this.ShouldSerializeProjectDeploymentProcessSnapshotIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeProjectIdValue { get; set; } = true;

                public bool ShouldSerializeProjectId()
                {
                        return this.ShouldSerializeProjectIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeProjectVariableSetSnapshotIdValue { get; set; } = true;

                public bool ShouldSerializeProjectVariableSetSnapshotId()
                {
                        return this.ShouldSerializeProjectVariableSetSnapshotIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeVersionValue { get; set; } = true;

                public bool ShouldSerializeVersion()
                {
                        return this.ShouldSerializeVersionValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeAssembledValue = false;
                        this.ShouldSerializeChannelIdValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeJSONValue = false;
                        this.ShouldSerializeProjectDeploymentProcessSnapshotIdValue = false;
                        this.ShouldSerializeProjectIdValue = false;
                        this.ShouldSerializeProjectVariableSetSnapshotIdValue = false;
                        this.ShouldSerializeVersionValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>aa95e2f596ede82bfb4bc04e12c5892b</Hash>
</Codenesium>*/