using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
        public partial class ApiChainResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        int chainStatusId,
                        Guid externalId,
                        string name,
                        int teamId)
                {
                        this.Id = id;
                        this.ChainStatusId = chainStatusId;
                        this.ExternalId = externalId;
                        this.Name = name;
                        this.TeamId = teamId;

                        this.ChainStatusIdEntity = nameof(ApiResponse.ChainStatus);
                        this.TeamIdEntity = nameof(ApiResponse.Teams);
                }

                [Required]
                [JsonProperty]
                public int ChainStatusId { get; private set; }

                [JsonProperty]
                public string ChainStatusIdEntity { get; set; }

                [Required]
                [JsonProperty]
                public Guid ExternalId { get; private set; }

                [Required]
                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public string Name { get; private set; }

                [Required]
                [JsonProperty]
                public int TeamId { get; private set; }

                [JsonProperty]
                public string TeamIdEntity { get; set; }
        }
}

/*<Codenesium>
    <Hash>95038107a0779dfad94056f220cdea16</Hash>
</Codenesium>*/