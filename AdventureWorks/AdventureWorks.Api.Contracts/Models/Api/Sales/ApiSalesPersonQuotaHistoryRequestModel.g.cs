using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiSalesPersonQuotaHistoryRequestModel : AbstractApiRequestModel
        {
                public ApiSalesPersonQuotaHistoryRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        DateTime modifiedDate,
                        DateTime quotaDate,
                        Guid rowguid,
                        decimal salesQuota)
                {
                        this.ModifiedDate = modifiedDate;
                        this.QuotaDate = quotaDate;
                        this.Rowguid = rowguid;
                        this.SalesQuota = salesQuota;
                }

                [Required]
                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [Required]
                [JsonProperty]
                public DateTime QuotaDate { get; private set; }

                [Required]
                [JsonProperty]
                public Guid Rowguid { get; private set; }

                [Required]
                [JsonProperty]
                public decimal SalesQuota { get; private set; }
        }
}

/*<Codenesium>
    <Hash>58fdbb68221a76b8a611b493e5b48429</Hash>
</Codenesium>*/