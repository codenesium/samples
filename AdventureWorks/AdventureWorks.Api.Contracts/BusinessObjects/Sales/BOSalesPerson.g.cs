using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOSalesPerson: AbstractBusinessObject
	{
		public BOSalesPerson() : base()
		{}

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
			this.Bonus = bonus.ToDecimal();
			this.BusinessEntityID = businessEntityID.ToInt();
			this.CommissionPct = commissionPct.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Rowguid = rowguid.ToGuid();
			this.SalesLastYear = salesLastYear.ToDecimal();
			this.SalesQuota = salesQuota.ToNullableDecimal();
			this.SalesYTD = salesYTD.ToDecimal();
			this.TerritoryID = territoryID.ToNullableInt();
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
    <Hash>2322f6a1c58e39efb437aeb72441008c</Hash>
</Codenesium>*/