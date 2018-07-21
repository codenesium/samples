using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
        public partial class ApiLinkLogRequestModel : AbstractApiRequestModel
        {
                public ApiLinkLogRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        DateTime dateEntered,
                        int linkId,
                        string log)
                {
                        this.DateEntered = dateEntered;
                        this.LinkId = linkId;
                        this.Log = log;
                }

                [JsonProperty]
                public DateTime DateEntered { get; private set; }

                [JsonProperty]
                public int LinkId { get; private set; }

                [JsonProperty]
                public string Log { get; private set; }
        }
}

/*<Codenesium>
    <Hash>33507d9f5a60221cdd76d9d7f71231e1</Hash>
</Codenesium>*/