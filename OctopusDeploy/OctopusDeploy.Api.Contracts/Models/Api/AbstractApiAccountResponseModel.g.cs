using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiAccountResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string accountType,
                        string environmentIds,
                        string id,
                        string jSON,
                        string name,
                        string tenantIds,
                        string tenantTags)
                {
                        this.AccountType = accountType;
                        this.EnvironmentIds = environmentIds;
                        this.Id = id;
                        this.JSON = jSON;
                        this.Name = name;
                        this.TenantIds = tenantIds;
                        this.TenantTags = tenantTags;
                }

                public string AccountType { get; private set; }

                public string EnvironmentIds { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }

                public string TenantIds { get; private set; }

                public string TenantTags { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeAccountTypeValue { get; set; } = true;

                public bool ShouldSerializeAccountType()
                {
                        return this.ShouldSerializeAccountTypeValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeEnvironmentIdsValue { get; set; } = true;

                public bool ShouldSerializeEnvironmentIds()
                {
                        return this.ShouldSerializeEnvironmentIdsValue;
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
                public bool ShouldSerializeTenantIdsValue { get; set; } = true;

                public bool ShouldSerializeTenantIds()
                {
                        return this.ShouldSerializeTenantIdsValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTenantTagsValue { get; set; } = true;

                public bool ShouldSerializeTenantTags()
                {
                        return this.ShouldSerializeTenantTagsValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeAccountTypeValue = false;
                        this.ShouldSerializeEnvironmentIdsValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeJSONValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeTenantIdsValue = false;
                        this.ShouldSerializeTenantTagsValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>5baf24df9ec0e79dd8515fb15dea092d</Hash>
</Codenesium>*/