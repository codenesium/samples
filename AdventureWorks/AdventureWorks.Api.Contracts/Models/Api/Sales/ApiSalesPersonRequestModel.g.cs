using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiSalesPersonRequestModel : AbstractApiRequestModel
        {
                public ApiSalesPersonRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        decimal bonus,
                        decimal commissionPct,
                        DateTime modifiedDate,
                        Guid rowguid,
                        decimal salesLastYear,
                        decimal? salesQuota,
                        decimal salesYTD,
                        int? territoryID)
                {
                        this.Bonus = bonus;
                        this.CommissionPct = commissionPct;
                        this.ModifiedDate = modifiedDate;
                        this.Rowguid = rowguid;
                        this.SalesLastYear = salesLastYear;
                        this.SalesQuota = salesQuota;
                        this.SalesYTD = salesYTD;
                        this.TerritoryID = territoryID;
                }

                [Required]
                [JsonProperty]
                public decimal Bonus { get; private set; }

                [Required]
                [JsonProperty]
                public decimal CommissionPct { get; private set; }

                [Required]
                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [Required]
                [JsonProperty]
                public Guid Rowguid { get; private set; }

                [Required]
                [JsonProperty]
                public decimal SalesLastYear { get; private set; }

                [JsonProperty]
                public decimal? SalesQuota { get; private set; }

                [Required]
                [JsonProperty]
                public decimal SalesYTD { get; private set; }

                [JsonProperty]
                public int? TerritoryID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>ff614f89537c3a45f5276a46d2f6b63d</Hash>
</Codenesium>*/