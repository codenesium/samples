using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOSalesPerson: AbstractDTO
	{
		public DTOSalesPerson() : base()
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

		public decimal Bonus { get; set; }
		public int BusinessEntityID { get; set; }
		public decimal CommissionPct { get; set; }
		public DateTime ModifiedDate { get; set; }
		public Guid Rowguid { get; set; }
		public decimal SalesLastYear { get; set; }
		public Nullable<decimal> SalesQuota { get; set; }
		public decimal SalesYTD { get; set; }
		public Nullable<int> TerritoryID { get; set; }
	}
}

/*<Codenesium>
    <Hash>c408bb2e7e1e9033ac4fd93cf26133b2</Hash>
</Codenesium>*/