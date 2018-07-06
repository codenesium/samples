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
        }
}

/*<Codenesium>
    <Hash>6343d8c48f4d77bdd2b7100ddb5c3430</Hash>
</Codenesium>*/