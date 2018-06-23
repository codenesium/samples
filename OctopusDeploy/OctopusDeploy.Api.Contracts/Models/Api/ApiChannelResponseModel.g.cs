using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public class ApiChannelResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        byte[] dataVersion,
                        string id,
                        string jSON,
                        string lifecycleId,
                        string name,
                        string projectId,
                        string tenantTags)
                {
                        this.DataVersion = dataVersion;
                        this.Id = id;
                        this.JSON = jSON;
                        this.LifecycleId = lifecycleId;
                        this.Name = name;
                        this.ProjectId = projectId;
                        this.TenantTags = tenantTags;
                }

                public byte[] DataVersion { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string LifecycleId { get; private set; }

                public string Name { get; private set; }

                public string ProjectId { get; private set; }

                public string TenantTags { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeDataVersionValue { get; set; } = true;

                public bool ShouldSerializeDataVersion()
                {
                        return this.ShouldSerializeDataVersionValue;
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
                public bool ShouldSerializeProjectIdValue { get; set; } = true;

                public bool ShouldSerializeProjectId()
                {
                        return this.ShouldSerializeProjectIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTenantTagsValue { get; set; } = true;

                public bool ShouldSerializeTenantTags()
                {
                        return this.ShouldSerializeTenantTagsValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeDataVersionValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeJSONValue = false;
                        this.ShouldSerializeLifecycleIdValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeProjectIdValue = false;
                        this.ShouldSerializeTenantTagsValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>90e437212a1f751b835761b58abbb782</Hash>
</Codenesium>*/