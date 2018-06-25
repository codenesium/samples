using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiProjectResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        bool autoCreateRelease,
                        byte[] dataVersion,
                        string deploymentProcessId,
                        bool discreteChannelRelease,
                        string id,
                        string includedLibraryVariableSetIds,
                        bool isDisabled,
                        string jSON,
                        string lifecycleId,
                        string name,
                        string projectGroupId,
                        string slug,
                        string variableSetId)
                {
                        this.AutoCreateRelease = autoCreateRelease;
                        this.DataVersion = dataVersion;
                        this.DeploymentProcessId = deploymentProcessId;
                        this.DiscreteChannelRelease = discreteChannelRelease;
                        this.Id = id;
                        this.IncludedLibraryVariableSetIds = includedLibraryVariableSetIds;
                        this.IsDisabled = isDisabled;
                        this.JSON = jSON;
                        this.LifecycleId = lifecycleId;
                        this.Name = name;
                        this.ProjectGroupId = projectGroupId;
                        this.Slug = slug;
                        this.VariableSetId = variableSetId;
                }

                public bool AutoCreateRelease { get; private set; }

                public byte[] DataVersion { get; private set; }

                public string DeploymentProcessId { get; private set; }

                public bool DiscreteChannelRelease { get; private set; }

                public string Id { get; private set; }

                public string IncludedLibraryVariableSetIds { get; private set; }

                public bool IsDisabled { get; private set; }

                public string JSON { get; private set; }

                public string LifecycleId { get; private set; }

                public string Name { get; private set; }

                public string ProjectGroupId { get; private set; }

                public string Slug { get; private set; }

                public string VariableSetId { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeAutoCreateReleaseValue { get; set; } = true;

                public bool ShouldSerializeAutoCreateRelease()
                {
                        return this.ShouldSerializeAutoCreateReleaseValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeDataVersionValue { get; set; } = true;

                public bool ShouldSerializeDataVersion()
                {
                        return this.ShouldSerializeDataVersionValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeDeploymentProcessIdValue { get; set; } = true;

                public bool ShouldSerializeDeploymentProcessId()
                {
                        return this.ShouldSerializeDeploymentProcessIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeDiscreteChannelReleaseValue { get; set; } = true;

                public bool ShouldSerializeDiscreteChannelRelease()
                {
                        return this.ShouldSerializeDiscreteChannelReleaseValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIncludedLibraryVariableSetIdsValue { get; set; } = true;

                public bool ShouldSerializeIncludedLibraryVariableSetIds()
                {
                        return this.ShouldSerializeIncludedLibraryVariableSetIdsValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIsDisabledValue { get; set; } = true;

                public bool ShouldSerializeIsDisabled()
                {
                        return this.ShouldSerializeIsDisabledValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeJSONValue { get; set; } = true;

                public bool ShouldSerializeJSON()
                {
                        return this.ShouldSerializeJSONValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeLifecycleIdValue { get; set; } = true;

                public bool ShouldSerializeLifecycleId()
                {
                        return this.ShouldSerializeLifecycleIdValue;
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
                public bool ShouldSerializeSlugValue { get; set; } = true;

                public bool ShouldSerializeSlug()
                {
                        return this.ShouldSerializeSlugValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeVariableSetIdValue { get; set; } = true;

                public bool ShouldSerializeVariableSetId()
                {
                        return this.ShouldSerializeVariableSetIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeAutoCreateReleaseValue = false;
                        this.ShouldSerializeDataVersionValue = false;
                        this.ShouldSerializeDeploymentProcessIdValue = false;
                        this.ShouldSerializeDiscreteChannelReleaseValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeIncludedLibraryVariableSetIdsValue = false;
                        this.ShouldSerializeIsDisabledValue = false;
                        this.ShouldSerializeJSONValue = false;
                        this.ShouldSerializeLifecycleIdValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeProjectGroupIdValue = false;
                        this.ShouldSerializeSlugValue = false;
                        this.ShouldSerializeVariableSetIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>3ce72df09d5077f17a94b02435996eec</Hash>
</Codenesium>*/