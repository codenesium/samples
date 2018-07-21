using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
        public partial class ApiLinkResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        int? assignedMachineId,
                        int chainId,
                        DateTime? dateCompleted,
                        DateTime? dateStarted,
                        string dynamicParameters,
                        Guid externalId,
                        int linkStatusId,
                        string name,
                        int order,
                        string response,
                        string staticParameters,
                        int timeoutInSeconds)
                {
                        this.Id = id;
                        this.AssignedMachineId = assignedMachineId;
                        this.ChainId = chainId;
                        this.DateCompleted = dateCompleted;
                        this.DateStarted = dateStarted;
                        this.DynamicParameters = dynamicParameters;
                        this.ExternalId = externalId;
                        this.LinkStatusId = linkStatusId;
                        this.Name = name;
                        this.Order = order;
                        this.Response = response;
                        this.StaticParameters = staticParameters;
                        this.TimeoutInSeconds = timeoutInSeconds;

                        this.AssignedMachineIdEntity = nameof(ApiResponse.Machines);
                        this.ChainIdEntity = nameof(ApiResponse.Chains);
                        this.LinkStatusIdEntity = nameof(ApiResponse.LinkStatus);
                }

                [Required]
                [JsonProperty]
                public int? AssignedMachineId { get; private set; }

                [JsonProperty]
                public string AssignedMachineIdEntity { get; set; }

                [Required]
                [JsonProperty]
                public int ChainId { get; private set; }

                [JsonProperty]
                public string ChainIdEntity { get; set; }

                [Required]
                [JsonProperty]
                public DateTime? DateCompleted { get; private set; }

                [Required]
                [JsonProperty]
                public DateTime? DateStarted { get; private set; }

                [Required]
                [JsonProperty]
                public string DynamicParameters { get; private set; }

                [Required]
                [JsonProperty]
                public Guid ExternalId { get; private set; }

                [Required]
                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public int LinkStatusId { get; private set; }

                [JsonProperty]
                public string LinkStatusIdEntity { get; set; }

                [Required]
                [JsonProperty]
                public string Name { get; private set; }

                [Required]
                [JsonProperty]
                public int Order { get; private set; }

                [Required]
                [JsonProperty]
                public string Response { get; private set; }

                [Required]
                [JsonProperty]
                public string StaticParameters { get; private set; }

                [Required]
                [JsonProperty]
                public int TimeoutInSeconds { get; private set; }
        }
}

/*<Codenesium>
    <Hash>41fa2854e1b09bb892079574f82fb075</Hash>
</Codenesium>*/