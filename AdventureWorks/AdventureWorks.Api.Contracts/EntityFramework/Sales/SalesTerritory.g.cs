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
		public int TerritoryID {get; set;}
		public string Name {get; set;}
		public string CountryRegionCode {get; set;}
		public string @Group {get; set;}
		public decimal SalesYTD {get; set;}
		public decimal SalesLastYear {get; set;}
		public decimal CostYTD {get; set;}
		public decimal CostLastYear {get; set;}
		public Guid rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("CountryRegionCode")]
		public virtual EFCountryRegion CountryRegionRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>84950a237aa3e2d9ab5bb48a489594e9</Hash>
</Codenesium>*/