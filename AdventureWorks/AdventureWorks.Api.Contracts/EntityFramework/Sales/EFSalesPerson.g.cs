using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("SalesPerson", Schema="Sales")]
	public partial class EFSalesPerson
	{
		public EFSalesPerson()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID {get; set;}

		[Column("TerritoryID", TypeName="int")]
		public Nullable<int> TerritoryID {get; set;}

		[Column("SalesQuota", TypeName="money")]
		public Nullable<decimal> SalesQuota {get; set;}

		[Column("Bonus", TypeName="money")]
		public decimal Bonus {get; set;}

		[Column("CommissionPct", TypeName="smallmoney")]
		public decimal CommissionPct {get; set;}

		[Column("SalesYTD", TypeName="money")]
		public decimal SalesYTD {get; set;}

		[Column("SalesLastYear", TypeName="money")]
		public decimal SalesLastYear {get; set;}

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		public virtual EFEmployee Employee { get; set; }

		public virtual EFSalesTerritory SalesTerritory { get; set; }
	}
}

/*<Codenesium>
    <Hash>eba50801ac950404df7df4a7e3c42590</Hash>
</Codenesium>*/