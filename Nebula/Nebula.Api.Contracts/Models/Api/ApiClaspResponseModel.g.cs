using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
        public partial class ApiClaspResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        int nextChainId,
                        int previousChainId)
                {
                        this.Id = id;
                        this.NextChainId = nextChainId;
                        this.PreviousChainId = previousChainId;

                        this.NextChainIdEntity = nameof(ApiResponse.Chains);
                        this.PreviousChainIdEntity = nameof(ApiResponse.Chains);
                }

                public int Id { get; private set; }

                public int NextChainId { get; private set; }

                public string NextChainIdEntity { get; set; }

                public int PreviousChainId { get; private set; }

                public string PreviousChainIdEntity { get; set; }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNextChainIdValue { get; set; } = true;

                public bool ShouldSerializeNextChainId()
                {
                        return this.ShouldSerializeNextChainIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePreviousChainIdValue { get; set; } = true;

                public bool ShouldSerializePreviousChainId()
                {
                        return this.ShouldSerializePreviousChainIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeNextChainIdValue = false;
                        this.ShouldSerializePreviousChainIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>a398e8d8a6f5ab14d9ca32d1b137418f</Hash>
</Codenesium>*/