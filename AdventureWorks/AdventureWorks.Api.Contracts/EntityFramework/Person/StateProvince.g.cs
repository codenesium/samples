using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("StateProvince", Schema="Person")]
	public partial class EFStateProvince
	{
		public EFStateProvince()
		{}

		[Key]
		public int StateProvinceID {get; set;}
		public string StateProvinceCode {get; set;}
		public string CountryRegionCode {get; set;}
		public bool IsOnlyStateProvinceFlag {get; set;}
		public string Name {get; set;}
		public int TerritoryID {get; set;}
		public Guid rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("CountryRegionCode")]
		public virtual EFCountryRegion CountryRegionRef { get; set; }
		[ForeignKey("TerritoryID")]
		public virtual EFSalesTerritory SalesTerritoryRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>ecd877d4062f322322e98bceed4ab37e</Hash>
</Codenesium>*/