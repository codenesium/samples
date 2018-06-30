using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiMachineResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
                        string communicationStyle,
                        string environmentIds,
                        string fingerprint,
                        bool isDisabled,
                        string jSON,
                        string machinePolicyId,
                        string name,
                        string relatedDocumentIds,
                        string roles,
                        string tenantIds,
                        string tenantTags,
                        string thumbprint)
                {
                        this.Id = id;
                        this.CommunicationStyle = communicationStyle;
                        this.EnvironmentIds = environmentIds;
                        this.Fingerprint = fingerprint;
                        this.IsDisabled = isDisabled;
                        this.JSON = jSON;
                        this.MachinePolicyId = machinePolicyId;
                        this.Name = name;
                        this.RelatedDocumentIds = relatedDocumentIds;
                        this.Roles = roles;
                        this.TenantIds = tenantIds;
                        this.TenantTags = tenantTags;
                        this.Thumbprint = thumbprint;
                }

                public string CommunicationStyle { get; private set; }

                public string EnvironmentIds { get; private set; }

                public string Fingerprint { get; private set; }

                public string Id { get; private set; }

                public bool IsDisabled { get; private set; }

                public string JSON { get; private set; }

                public string MachinePolicyId { get; private set; }

                public string Name { get; private set; }

                public string RelatedDocumentIds { get; private set; }

                public string Roles { get; private set; }

                public string TenantIds { get; private set; }

                public string TenantTags { get; private set; }

                public string Thumbprint { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeCommunicationStyleValue { get; set; } = true;

                public bool ShouldSerializeCommunicationStyle()
                {
                        return this.ShouldSerializeCommunicationStyleValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeEnvironmentIdsValue { get; set; } = true;

                public bool ShouldSerializeEnvironmentIds()
                {
                        return this.ShouldSerializeEnvironmentIdsValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeFingerprintValue { get; set; } = true;

                public bool ShouldSerializeFingerprint()
                {
                        return this.ShouldSerializeFingerprintValue;
                }

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
                public bool ShouldSerializeMachinePolicyIdValue { get; set; } = true;

                public bool ShouldSerializeMachinePolicyId()
                {
                        return this.ShouldSerializeMachinePolicyIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNameValue { get; set; } = true;

                public bool ShouldSerializeName()
                {
                        return this.ShouldSerializeNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeRelatedDocumentIdsValue { get; set; } = true;

                public bool ShouldSerializeRelatedDocumentIds()
                {
                        return this.ShouldSerializeRelatedDocumentIdsValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeRolesValue { get; set; } = true;

                public bool ShouldSerializeRoles()
                {
                        return this.ShouldSerializeRolesValue;
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

                [JsonIgnore]
                public bool ShouldSerializeThumbprintValue { get; set; } = true;

                public bool ShouldSerializeThumbprint()
                {
                        return this.ShouldSerializeThumbprintValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeCommunicationStyleValue = false;
                        this.ShouldSerializeEnvironmentIdsValue = false;
                        this.ShouldSerializeFingerprintValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeIsDisabledValue = false;
                        this.ShouldSerializeJSONValue = false;
                        this.ShouldSerializeMachinePolicyIdValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeRelatedDocumentIdsValue = false;
                        this.ShouldSerializeRolesValue = false;
                        this.ShouldSerializeTenantIdsValue = false;
                        this.ShouldSerializeTenantTagsValue = false;
                        this.ShouldSerializeThumbprintValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>55fde93c188cff40fa127060057627a6</Hash>
</Codenesium>*/