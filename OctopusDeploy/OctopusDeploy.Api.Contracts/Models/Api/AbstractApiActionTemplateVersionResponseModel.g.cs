using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiActionTemplateVersionResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string actionType,
                        string id,
                        string jSON,
                        string latestActionTemplateId,
                        string name,
                        int version)
                {
                        this.ActionType = actionType;
                        this.Id = id;
                        this.JSON = jSON;
                        this.LatestActionTemplateId = latestActionTemplateId;
                        this.Name = name;
                        this.Version = version;
                }

                public string ActionType { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string LatestActionTemplateId { get; private set; }

                public string Name { get; private set; }

                public int Version { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeActionTypeValue { get; set; } = true;

                public bool ShouldSerializeActionType()
                {
                        return this.ShouldSerializeActionTypeValue;
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
                public bool ShouldSerializeLatestActionTemplateIdValue { get; set; } = true;

                public bool ShouldSerializeLatestActionTemplateId()
                {
                        return this.ShouldSerializeLatestActionTemplateIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNameValue { get; set; } = true;

                public bool ShouldSerializeName()
                {
                        return this.ShouldSerializeNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeVersionValue { get; set; } = true;

                public bool ShouldSerializeVersion()
                {
                        return this.ShouldSerializeVersionValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeActionTypeValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeJSONValue = false;
                        this.ShouldSerializeLatestActionTemplateIdValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeVersionValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>b174129ea37fd212dec8f0da117dc21c</Hash>
</Codenesium>*/