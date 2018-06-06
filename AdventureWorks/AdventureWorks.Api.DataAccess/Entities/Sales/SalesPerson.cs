using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SalesPerson", Schema="Sales")]
	public partial class SalesPerson: AbstractEntity
	{
		public SalesPerson()
		{}

		public void SetProperties(
			decimal bonus,
			int businessEntityID,
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

		[Column("Bonus", TypeName="money")]
		public decimal Bonus { get; private set; }

		[Key]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; private set; }

		[Column("CommissionPct", TypeName="smallmoney")]
		public decimal CommissionPct { get; private set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; private set; }

		[Column("SalesLastYear", TypeName="money")]
		public decimal SalesLastYear { get; private set; }

		[Column("SalesQuota", TypeName="money")]
		public Nullable<decimal> SalesQuota { get; private set; }

		[Column("SalesYTD", TypeName="money")]
		public decimal SalesYTD { get; private set; }

		[Column("TerritoryID", TypeName="int")]
		public Nullable<int> TerritoryID { get; private set; }

		[ForeignKey("TerritoryID")]
		public virtual SalesTerritory SalesTerritory { get; set; }
	}
}

/*<Codenesium>
    <Hash>f0e587b36d2ea89862ca16346696bd4d</Hash>
</Codenesium>*/