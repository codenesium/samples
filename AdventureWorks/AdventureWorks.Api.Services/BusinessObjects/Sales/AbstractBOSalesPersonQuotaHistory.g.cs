using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOSalesPersonQuotaHistory: AbstractBusinessObject
        {
                public AbstractBOSalesPersonQuotaHistory() : base()
                {
                }

                public virtual void SetProperties(int businessEntityID,
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
    <Hash>dede12cc8aa88faa0e0ec945b9d31416</Hash>
</Codenesium>*/