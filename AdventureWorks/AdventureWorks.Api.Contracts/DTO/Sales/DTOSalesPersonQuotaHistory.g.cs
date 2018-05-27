using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOSalesPersonQuotaHistory: AbstractDTO
	{
		public DTOSalesPersonQuotaHistory() : base()
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

		public int BusinessEntityID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public DateTime QuotaDate { get; set; }
		public Guid Rowguid { get; set; }
		public decimal SalesQuota { get; set; }
	}
}

/*<Codenesium>
    <Hash>cbada1ac1ccce17a4d460274de1b4dc7</Hash>
</Codenesium>*/