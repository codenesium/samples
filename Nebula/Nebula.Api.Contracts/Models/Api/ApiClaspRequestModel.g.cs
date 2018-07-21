using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
        public partial class ApiClaspRequestModel : AbstractApiRequestModel
        {
                public ApiClaspRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        int nextChainId,
                        int previousChainId)
                {
                        this.NextChainId = nextChainId;
                        this.PreviousChainId = previousChainId;
                }

                [JsonProperty]
                public int NextChainId { get; private set; }

                [JsonProperty]
                public int PreviousChainId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>6ada03cee1eab531a32a576b37a634b8</Hash>
</Codenesium>*/