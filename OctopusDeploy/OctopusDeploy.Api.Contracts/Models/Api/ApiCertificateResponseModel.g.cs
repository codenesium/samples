using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public class ApiCertificateResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        Nullable<DateTimeOffset> archived,
                        DateTimeOffset created,
                        byte[] dataVersion,
                        string environmentIds,
                        string id,
                        string jSON,
                        string name,
                        DateTimeOffset notAfter,
                        string subject,
                        string tenantIds,
                        string tenantTags,
                        string thumbprint)
                {
                        this.Archived = archived;
                        this.Created = created;
                        this.DataVersion = dataVersion;
                        this.EnvironmentIds = environmentIds;
                        this.Id = id;
                        this.JSON = jSON;
                        this.Name = name;
                        this.NotAfter = notAfter;
                        this.Subject = subject;
                        this.TenantIds = tenantIds;
                        this.TenantTags = tenantTags;
                        this.Thumbprint = thumbprint;
                }

                public Nullable<DateTimeOffset> Archived { get; private set; }

                public DateTimeOffset Created { get; private set; }

                public byte[] DataVersion { get; private set; }

                public string EnvironmentIds { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }

                public DateTimeOffset NotAfter { get; private set; }

                public string Subject { get; private set; }

                public string TenantIds { get; private set; }

                public string TenantTags { get; private set; }

                public string Thumbprint { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeArchivedValue { get; set; } = true;

                public bool ShouldSerializeArchived()
                {
                        return this.ShouldSerializeArchivedValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeCreatedValue { get; set; } = true;

                public bool ShouldSerializeCreated()
                {
                        return this.ShouldSerializeCreatedValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeDataVersionValue { get; set; } = true;

                public bool ShouldSerializeDataVersion()
                {
                        return this.ShouldSerializeDataVersionValue;
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
                public bool ShouldSerializeNotAfterValue { get; set; } = true;

                public bool ShouldSerializeNotAfter()
                {
                        return this.ShouldSerializeNotAfterValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeSubjectValue { get; set; } = true;

                public bool ShouldSerializeSubject()
                {
                        return this.ShouldSerializeSubjectValue;
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
                        this.ShouldSerializeArchivedValue = false;
                        this.ShouldSerializeCreatedValue = false;
                        this.ShouldSerializeDataVersionValue = false;
                        this.ShouldSerializeEnvironmentIdsValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeJSONValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeNotAfterValue = false;
                        this.ShouldSerializeSubjectValue = false;
                        this.ShouldSerializeTenantIdsValue = false;
                        this.ShouldSerializeTenantTagsValue = false;
                        this.ShouldSerializeThumbprintValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>d969f6f693fe9c8e14b4ed7f328e640e</Hash>
</Codenesium>*/