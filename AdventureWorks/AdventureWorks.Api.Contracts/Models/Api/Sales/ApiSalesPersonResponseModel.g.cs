using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiSalesPersonResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int businessEntityID,
                        decimal bonus,
                        decimal commissionPct,
                        DateTime modifiedDate,
                        Guid rowguid,
                        decimal salesLastYear,
                        decimal? salesQuota,
                        decimal salesYTD,
                        int? territoryID)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.Bonus = bonus;
                        this.CommissionPct = commissionPct;
                        this.ModifiedDate = modifiedDate;
                        this.Rowguid = rowguid;
                        this.SalesLastYear = salesLastYear;
                        this.SalesQuota = salesQuota;
                        this.SalesYTD = salesYTD;
                        this.TerritoryID = territoryID;

                        this.TerritoryIDEntity = nameof(ApiResponse.SalesTerritories);
                }

                public decimal Bonus { get; private set; }

                public int BusinessEntityID { get; private set; }

                public decimal CommissionPct { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public Guid Rowguid { get; private set; }

                public decimal SalesLastYear { get; private set; }

                public decimal? SalesQuota { get; private set; }

                public decimal SalesYTD { get; private set; }

                public int? TerritoryID { get; private set; }

                public string TerritoryIDEntity { get; set; }
        }
}

/*<Codenesium>
    <Hash>21320de576cb748e6383c3b8dd00d8e3</Hash>
</Codenesium>*/