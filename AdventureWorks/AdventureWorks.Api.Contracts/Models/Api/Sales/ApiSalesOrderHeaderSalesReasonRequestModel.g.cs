using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiSalesOrderHeaderSalesReasonRequestModel : AbstractApiRequestModel
        {
                public ApiSalesOrderHeaderSalesReasonRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        DateTime modifiedDate,
                        int salesReasonID)
                {
                        this.ModifiedDate = modifiedDate;
                        this.SalesReasonID = salesReasonID;
                }

                [Required]
                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [Required]
                [JsonProperty]
                public int SalesReasonID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>00868cab4d4410e1774c871d6a38003d</Hash>
</Codenesium>*/