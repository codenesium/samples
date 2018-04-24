using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SalesPerson", Schema="Sales")]
	public partial class EFSalesPerson: AbstractEntityFrameworkPOCO
	{
		public EFSalesPerson()
		{}

		public void SetProperties(
			int businessEntityID,
			Nullable<int> territoryID,
			Nullable<decimal> salesQuota,
			decimal bonus,
			decimal commissionPct,
			decimal salesYTD,
			decimal salesLastYear,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.TerritoryID = territoryID.ToNullableInt();
			this.SalesQuota = salesQuota.ToNullableDecimal();
			this.Bonus = bonus.ToDecimal();
			this.CommissionPct = commissionPct.ToDecimal();
			this.SalesYTD = salesYTD.ToDecimal();
			this.SalesLastYear = salesLastYear.ToDecimal();
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; set; }

		[Column("TerritoryID", TypeName="int")]
		public Nullable<int> TerritoryID { get; set; }

		[Column("SalesQuota", TypeName="money")]
		public Nullable<decimal> SalesQuota { get; set; }

		[Column("Bonus", TypeName="money")]
		public decimal Bonus { get; set; }

		[Column("CommissionPct", TypeName="smallmoney")]
		public decimal CommissionPct { get; set; }

		[Column("SalesYTD", TypeName="money")]
		public decimal SalesYTD { get; set; }

		[Column("SalesLastYear", TypeName="money")]
		public decimal SalesLastYear { get; set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("BusinessEntityID")]
		public virtual EFEmployee Employee { get; set; }

		[ForeignKey("TerritoryID")]
		public virtual EFSalesTerritory SalesTerritory { get; set; }
	}
}

/*<Codenesium>
    <Hash>35f92eafb1e6021e902a4ceb957bfaf7</Hash>
</Codenesium>*/