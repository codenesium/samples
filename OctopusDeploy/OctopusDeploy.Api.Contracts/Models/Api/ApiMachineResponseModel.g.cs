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

                [Required]
                [JsonProperty]
                public string CommunicationStyle { get; private set; }

                [Required]
                [JsonProperty]
                public string EnvironmentIds { get; private set; }

                [Required]
                [JsonProperty]
                public string Fingerprint { get; private set; }

                [Required]
                [JsonProperty]
                public string Id { get; private set; }

                [Required]
                [JsonProperty]
                public bool IsDisabled { get; private set; }

                [Required]
                [JsonProperty]
                public string JSON { get; private set; }

                [Required]
                [JsonProperty]
                public string MachinePolicyId { get; private set; }

                [Required]
                [JsonProperty]
                public string Name { get; private set; }

                [Required]
                [JsonProperty]
                public string RelatedDocumentIds { get; private set; }

                [Required]
                [JsonProperty]
                public string Roles { get; private set; }

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
    <Hash>4699506b21de3efab91438b2c98f35bd</Hash>
</Codenesium>*/