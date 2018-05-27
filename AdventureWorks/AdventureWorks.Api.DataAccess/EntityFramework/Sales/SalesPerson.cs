using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SalesPerson", Schema="Sales")]
	public partial class SalesPerson: AbstractEntityFrameworkDTO
	{
		public SalesPerson()
		{}

		public void SetProperties(
			int businessEntityID,
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

		[Column("Bonus", TypeName="money")]
		public decimal Bonus { get; set; }

		[Key]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; set; }

		[Column("CommissionPct", TypeName="smallmoney")]
		public decimal CommissionPct { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("SalesLastYear", TypeName="money")]
		public decimal SalesLastYear { get; set; }

		[Column("SalesQuota", TypeName="money")]
		public Nullable<decimal> SalesQuota { get; set; }

		[Column("SalesYTD", TypeName="money")]
		public decimal SalesYTD { get; set; }

		[Column("TerritoryID", TypeName="int")]
		public Nullable<int> TerritoryID { get; set; }

		[ForeignKey("TerritoryID")]
		public virtual SalesTerritory SalesTerritory { get; set; }
	}
}

/*<Codenesium>
    <Hash>846c5bb48e71e583249bdc7a07bb056b</Hash>
</Codenesium>*/