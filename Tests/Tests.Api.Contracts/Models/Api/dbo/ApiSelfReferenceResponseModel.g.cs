using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TestsNS.Api.Contracts
{
        public partial class ApiSelfReferenceResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        int? selfReferenceId,
                        int? selfReferenceId2)
                {
                        this.Id = id;
                        this.SelfReferenceId = selfReferenceId;
                        this.SelfReferenceId2 = selfReferenceId2;
                }

                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public int? SelfReferenceId { get; private set; }

                [Required]
                [JsonProperty]
                public int? SelfReferenceId2 { get; private set; }
        }
}

/*<Codenesium>
    <Hash>6ea469bad28359a25eee7e8392698c3c</Hash>
</Codenesium>*/