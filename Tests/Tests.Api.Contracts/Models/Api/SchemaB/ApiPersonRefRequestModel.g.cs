using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TestsNS.Api.Contracts
{
        public partial class ApiPersonRefRequestModel : AbstractApiRequestModel
        {
                public ApiPersonRefRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        int personAId,
                        int personBId)
                {
                        this.PersonAId = personAId;
                        this.PersonBId = personBId;
                }

                [Required]
                [JsonProperty]
                public int PersonAId { get; private set; }

                [Required]
                [JsonProperty]
                public int PersonBId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>3f35e2dff6376a5a9a7de7737074509a</Hash>
</Codenesium>*/