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

                public virtual void DisableAllFields()
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
    <Hash>2d0edecccd262d7715d6eff5ab10076d</Hash>
</Codenesium>*/