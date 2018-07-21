using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiBusinessEntityRequestModel : AbstractApiRequestModel
        {
                public ApiBusinessEntityRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        DateTime modifiedDate,
                        Guid rowguid)
                {
                        this.ModifiedDate = modifiedDate;
                        this.Rowguid = rowguid;
                }

                [Required]
                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [Required]
                [JsonProperty]
                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>11c5b8406af705292679ff45e8770193</Hash>
</Codenesium>*/