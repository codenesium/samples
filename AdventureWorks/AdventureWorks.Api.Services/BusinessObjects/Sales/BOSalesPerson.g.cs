using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOSalesPerson: AbstractBusinessObject
        {
                public BOSalesPerson() : base()
                {
                }

                public void SetProperties(int businessEntityID,
                                          decimal bonus,
                                          decimal commissionPct,
                                          DateTime modifiedDate,
                                          Guid rowguid,
                                          decimal salesLastYear,
                                          Nullable<decimal> salesQuota,
                                          decimal salesYTD,
                                          Nullable<int> territoryID)
                {
                        this.Bonus = bonus;
                        this.BusinessEntityID = businessEntityID;
                        this.CommissionPct = commissionPct;
                        this.ModifiedDate = modifiedDate;
                        this.Rowguid = rowguid;
                        this.SalesLastYear = salesLastYear;
                        this.SalesQuota = salesQuota;
                        this.SalesYTD = salesYTD;
                        this.TerritoryID = territoryID;
                }

                public decimal Bonus { get; private set; }

                public int BusinessEntityID { get; private set; }

                public decimal CommissionPct { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public Guid Rowguid { get; private set; }

                public decimal SalesLastYear { get; private set; }

                public Nullable<decimal> SalesQuota { get; private set; }

                public decimal SalesYTD { get; private set; }

                public Nullable<int> TerritoryID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>44a5a9d66910a5529fb88e775a2fd4d5</Hash>
</Codenesium>*/