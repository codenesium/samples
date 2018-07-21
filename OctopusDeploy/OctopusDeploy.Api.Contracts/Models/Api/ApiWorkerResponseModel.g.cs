using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiWorkerResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
                        string communicationStyle,
                        string fingerprint,
                        bool isDisabled,
                        string jSON,
                        string machinePolicyId,
                        string name,
                        string relatedDocumentIds,
                        string thumbprint,
                        string workerPoolIds)
                {
                        this.Id = id;
                        this.CommunicationStyle = communicationStyle;
                        this.Fingerprint = fingerprint;
                        this.IsDisabled = isDisabled;
                        this.JSON = jSON;
                        this.MachinePolicyId = machinePolicyId;
                        this.Name = name;
                        this.RelatedDocumentIds = relatedDocumentIds;
                        this.Thumbprint = thumbprint;
                        this.WorkerPoolIds = workerPoolIds;
                }

                [Required]
                [JsonProperty]
                public string CommunicationStyle { get; private set; }

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
                public string Thumbprint { get; private set; }

                [Required]
                [JsonProperty]
                public string WorkerPoolIds { get; private set; }
        }
}

/*<Codenesium>
    <Hash>8d4fc0a65e08182e1099c8a1a8132d27</Hash>
</Codenesium>*/