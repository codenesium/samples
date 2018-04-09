using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("SalesTerritory", Schema="Sales")]
	public partial class EFSalesTerritory
	{
		public EFSalesTerritory()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("TerritoryID", TypeName="int")]
		public int TerritoryID {get; set;}

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name {get; set;}

		[Column("CountryRegionCode", TypeName="nvarchar(3)")]
		public string CountryRegionCode {get; set;}

		[Column("Group", TypeName="nvarchar(50)")]
		public string @Group {get; set;}

		[Column("SalesYTD", TypeName="money")]
		public decimal SalesYTD {get; set;}

		[Column("SalesLastYear", TypeName="money")]
		public decimal SalesLastYear {get; set;}

		[Column("CostYTD", TypeName="money")]
		public decimal CostYTD {get; set;}

		[Column("CostLastYear", TypeName="money")]
		public decimal CostLastYear {get; set;}

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		public virtual EFCountryRegion CountryRegion { get; set; }
	}
}

/*<Codenesium>
    <Hash>ee792d0041537a105aa78179892b9724</Hash>
</Codenesium>*/