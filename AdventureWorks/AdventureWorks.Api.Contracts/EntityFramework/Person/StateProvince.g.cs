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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("StateProvinceID", TypeName="int")]
		public int StateProvinceID {get; set;}
		[Column("StateProvinceCode", TypeName="nchar(3)")]
		public string StateProvinceCode {get; set;}
		[Column("CountryRegionCode", TypeName="nvarchar(3)")]
		public string CountryRegionCode {get; set;}
		[Column("IsOnlyStateProvinceFlag", TypeName="bit")]
		public bool IsOnlyStateProvinceFlag {get; set;}
		[Column("Name", TypeName="nvarchar(50)")]
		public string Name {get; set;}
		[Column("TerritoryID", TypeName="int")]
		public int TerritoryID {get; set;}
		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid {get; set;}
		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("CountryRegionCode")]
		public virtual EFCountryRegion CountryRegionRef { get; set; }
		[ForeignKey("TerritoryID")]
		public virtual EFSalesTerritory SalesTerritoryRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>631720007d38212105f4fe4ad7fb9f49</Hash>
</Codenesium>*/