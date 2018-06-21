using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiProjectTriggerResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
                        bool isDisabled,
                        string jSON,
                        string name,
                        string projectId,
                        string triggerType)
                {
                        this.Id = id;
                        this.IsDisabled = isDisabled;
                        this.JSON = jSON;
                        this.Name = name;
                        this.ProjectId = projectId;
                        this.TriggerType = triggerType;
                }

                public string Id { get; private set; }

                public bool IsDisabled { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }

                public string ProjectId { get; private set; }

                public string TriggerType { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
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
                public bool ShouldSerializeNameValue { get; set; } = true;

                public bool ShouldSerializeName()
                {
                        return this.ShouldSerializeNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeProjectIdValue { get; set; } = true;

                public bool ShouldSerializeProjectId()
                {
                        return this.ShouldSerializeProjectIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTriggerTypeValue { get; set; } = true;

                public bool ShouldSerializeTriggerType()
                {
                        return this.ShouldSerializeTriggerTypeValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeIsDisabledValue = false;
                        this.ShouldSerializeJSONValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeProjectIdValue = false;
                        this.ShouldSerializeTriggerTypeValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>eb58bdeb6b3a507643c34e59f1c8ac83</Hash>
</Codenesium>*/