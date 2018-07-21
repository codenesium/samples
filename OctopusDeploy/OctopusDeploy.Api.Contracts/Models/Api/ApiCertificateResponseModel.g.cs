using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiCertificateResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
                        DateTimeOffset? archived,
                        DateTimeOffset created,
                        byte[] dataVersion,
                        string environmentIds,
                        string jSON,
                        string name,
                        DateTimeOffset notAfter,
                        string subject,
                        string tenantIds,
                        string tenantTags,
                        string thumbprint)
                {
                        this.Id = id;
                        this.Archived = archived;
                        this.Created = created;
                        this.DataVersion = dataVersion;
                        this.EnvironmentIds = environmentIds;
                        this.JSON = jSON;
                        this.Name = name;
                        this.NotAfter = notAfter;
                        this.Subject = subject;
                        this.TenantIds = tenantIds;
                        this.TenantTags = tenantTags;
                        this.Thumbprint = thumbprint;
                }

                [Required]
                [JsonProperty]
                public DateTimeOffset? Archived { get; private set; }

                [Required]
                [JsonProperty]
                public DateTimeOffset Created { get; private set; }

                [Required]
                [JsonProperty]
                public byte[] DataVersion { get; private set; }

                [Required]
                [JsonProperty]
                public string EnvironmentIds { get; private set; }

                [Required]
                [JsonProperty]
                public string Id { get; private set; }

                [Required]
                [JsonProperty]
                public string JSON { get; private set; }

                [Required]
                [JsonProperty]
                public string Name { get; private set; }

                [Required]
                [JsonProperty]
                public DateTimeOffset NotAfter { get; private set; }

                [Required]
                [JsonProperty]
                public string Subject { get; private set; }

                [Required]
                [JsonProperty]
                public string TenantIds { get; private set; }

                [Required]
                [JsonProperty]
                public string TenantTags { get; private set; }

                [Required]
                [JsonProperty]
                public string Thumbprint { get; private set; }
        }
}

/*<Codenesium>
    <Hash>1c9896f3b115c290b64312cf3c850007</Hash>
</Codenesium>*/