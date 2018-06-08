using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOSalesPersonQuotaHistory: AbstractBusinessObject
        {
                public BOSalesPersonQuotaHistory() : base()
                {
                }

                public void SetProperties(int businessEntityID,
                                          DateTime modifiedDate,
                                          DateTime quotaDate,
                                          Guid rowguid,
                                          decimal salesQuota)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.ModifiedDate = modifiedDate;
                        this.QuotaDate = quotaDate;
                        this.Rowguid = rowguid;
                        this.SalesQuota = salesQuota;
                }

                public int BusinessEntityID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public DateTime QuotaDate { get; private set; }

                public Guid Rowguid { get; private set; }

                public decimal SalesQuota { get; private set; }
        }
}

/*<Codenesium>
    <Hash>ce7486badbbcd89a1f67114774effb12</Hash>
</Codenesium>*/