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
		public virtual EFCountryRegion CountryRegion { get; set; }
		[ForeignKey("TerritoryID")]
		public virtual EFSalesTerritory SalesTerritory { get; set; }
	}
}

/*<Codenesium>
    <Hash>47efa925b1dade61ff437f81d0c9dc7d</Hash>
</Codenesium>*/