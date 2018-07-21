using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiSpecialOfferProductRequestModel : AbstractApiRequestModel
        {
                public ApiSpecialOfferProductRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        DateTime modifiedDate,
                        int productID,
                        Guid rowguid)
                {
                        this.ModifiedDate = modifiedDate;
                        this.ProductID = productID;
                        this.Rowguid = rowguid;
                }

                [Required]
                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [Required]
                [JsonProperty]
                public int ProductID { get; private set; }

                [Required]
                [JsonProperty]
                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>05503adc32c82908f6b4f20be6d5e8c0</Hash>
</Codenesium>*/