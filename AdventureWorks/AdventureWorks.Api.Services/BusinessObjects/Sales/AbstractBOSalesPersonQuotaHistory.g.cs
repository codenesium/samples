using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOSalesPersonQuotaHistory : AbstractBusinessObject
	{
		public AbstractBOSalesPersonQuotaHistory()
			: base()
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
    <Hash>70a378d06ca287c3574628dd620b7960</Hash>
</Codenesium>*/