using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiSalesReasonRequestModel : AbstractApiRequestModel
        {
                public ApiSalesReasonRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        DateTime modifiedDate,
                        string name,
                        string reasonType)
                {
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.ReasonType = reasonType;
                }

                [Required]
                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [Required]
                [JsonProperty]
                public string Name { get; private set; }

                [Required]
                [JsonProperty]
                public string ReasonType { get; private set; }
        }
}

/*<Codenesium>
    <Hash>bbe0c030bc5715cc6ff3e6606132f228</Hash>
</Codenesium>*/