using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiMachineRequestModel : AbstractApiRequestModel
        {
                public ApiMachineRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
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

                [JsonProperty]
                public string CommunicationStyle { get; private set; }

                [JsonProperty]
                public string EnvironmentIds { get; private set; }

                [JsonProperty]
                public string Fingerprint { get; private set; }

                [JsonProperty]
                public bool IsDisabled { get; private set; }

                [JsonProperty]
                public string JSON { get; private set; }

                [JsonProperty]
                public string MachinePolicyId { get; private set; }

                [JsonProperty]
                public string Name { get; private set; }

                [JsonProperty]
                public string RelatedDocumentIds { get; private set; }

                [JsonProperty]
                public string Roles { get; private set; }

                [JsonProperty]
                public string TenantIds { get; private set; }

                [JsonProperty]
                public string TenantTags { get; private set; }

                [JsonProperty]
                public string Thumbprint { get; private set; }
        }
}

/*<Codenesium>
    <Hash>233817241c615a3768d29241169099b3</Hash>
</Codenesium>*/