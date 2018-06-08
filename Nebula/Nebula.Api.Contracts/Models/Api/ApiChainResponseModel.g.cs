using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace NebulaNS.Api.Contracts
{
        public partial class ApiChainResponseModel: AbstractApiResponseModel
        {
                public ApiChainResponseModel() : base()
                {
                }

                public void SetProperties(
                        int chainStatusId,
                        Guid externalId,
                        int id,
                        string name,
                        int teamId)
                {
                        this.ChainStatusId = chainStatusId;
                        this.ExternalId = externalId;
                        this.Id = id;
                        this.Name = name;
                        this.TeamId = teamId;

                        this.ChainStatusIdEntity = nameof(ApiResponse.ChainStatus);
                        this.TeamIdEntity = nameof(ApiResponse.Teams);
                }

                public int ChainStatusId { get; private set; }

                public string ChainStatusIdEntity { get; set; }

                public Guid ExternalId { get; private set; }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public int TeamId { get; private set; }

                public string TeamIdEntity { get; set; }

                [JsonIgnore]
                public bool ShouldSerializeChainStatusIdValue { get; set; } = true;

                public bool ShouldSerializeChainStatusId()
                {
                        return this.ShouldSerializeChainStatusIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeExternalIdValue { get; set; } = true;

                public bool ShouldSerializeExternalId()
                {
                        return this.ShouldSerializeExternalIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNameValue { get; set; } = true;

                public bool ShouldSerializeName()
                {
                        return this.ShouldSerializeNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTeamIdValue { get; set; } = true;

                public bool ShouldSerializeTeamId()
                {
                        return this.ShouldSerializeTeamIdValue;
                }

                public void DisableAllFields()
                {
                        this.ShouldSerializeChainStatusIdValue = false;
                        this.ShouldSerializeExternalIdValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeTeamIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>8ca53acec21da290eaf69576799f9781</Hash>
</Codenesium>*/