using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiDeploymentResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
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

                public string ChannelId { get; private set; }

                public DateTime Created { get; private set; }

                public string DeployedBy { get; private set; }

                public string DeployedToMachineIds { get; private set; }

                public string EnvironmentId { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }

                public string ProjectGroupId { get; private set; }

                public string ProjectId { get; private set; }

                public string ReleaseId { get; private set; }

                public string TaskId { get; private set; }

                public string TenantId { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeChannelIdValue { get; set; } = true;

                public bool ShouldSerializeChannelId()
                {
                        return this.ShouldSerializeChannelIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeCreatedValue { get; set; } = true;

                public bool ShouldSerializeCreated()
                {
                        return this.ShouldSerializeCreatedValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeDeployedByValue { get; set; } = true;

                public bool ShouldSerializeDeployedBy()
                {
                        return this.ShouldSerializeDeployedByValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeDeployedToMachineIdsValue { get; set; } = true;

                public bool ShouldSerializeDeployedToMachineIds()
                {
                        return this.ShouldSerializeDeployedToMachineIdsValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeEnvironmentIdValue { get; set; } = true;

                public bool ShouldSerializeEnvironmentId()
                {
                        return this.ShouldSerializeEnvironmentIdValue;
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
                public bool ShouldSerializeNameValue { get; set; } = true;

                public bool ShouldSerializeName()
                {
                        return this.ShouldSerializeNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeProjectGroupIdValue { get; set; } = true;

                public bool ShouldSerializeProjectGroupId()
                {
                        return this.ShouldSerializeProjectGroupIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeProjectIdValue { get; set; } = true;

                public bool ShouldSerializeProjectId()
                {
                        return this.ShouldSerializeProjectIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeReleaseIdValue { get; set; } = true;

                public bool ShouldSerializeReleaseId()
                {
                        return this.ShouldSerializeReleaseIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTaskIdValue { get; set; } = true;

                public bool ShouldSerializeTaskId()
                {
                        return this.ShouldSerializeTaskIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTenantIdValue { get; set; } = true;

                public bool ShouldSerializeTenantId()
                {
                        return this.ShouldSerializeTenantIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeChannelIdValue = false;
                        this.ShouldSerializeCreatedValue = false;
                        this.ShouldSerializeDeployedByValue = false;
                        this.ShouldSerializeDeployedToMachineIdsValue = false;
                        this.ShouldSerializeEnvironmentIdValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeJSONValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeProjectGroupIdValue = false;
                        this.ShouldSerializeProjectIdValue = false;
                        this.ShouldSerializeReleaseIdValue = false;
                        this.ShouldSerializeTaskIdValue = false;
                        this.ShouldSerializeTenantIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>ed8b47c745e7d28c52e3839de9905056</Hash>
</Codenesium>*/