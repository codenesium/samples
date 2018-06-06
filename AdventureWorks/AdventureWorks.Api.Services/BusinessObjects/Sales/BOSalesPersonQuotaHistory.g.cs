using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
	public partial class BOSalesPersonQuotaHistory: AbstractBusinessObject
	{
		public BOSalesPersonQuotaHistory() : base()
		{}

		public void SetProperties(int businessEntityID,
		                          DateTime modifiedDate,
		                          DateTime quotaDate,
		                          Guid rowguid,
		                          decimal salesQuota)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.QuotaDate = quotaDate.ToDateTime();
			this.Rowguid = rowguid.ToGuid();
			this.SalesQuota = salesQuota.ToDecimal();
		}

		public int BusinessEntityID { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public DateTime QuotaDate { get; private set; }
		public Guid Rowguid { get; private set; }
		public decimal SalesQuota { get; private set; }
	}
}

/*<Codenesium>
    <Hash>4abbdf842d57c1ce086f438b4c89b214</Hash>
</Codenesium>*/